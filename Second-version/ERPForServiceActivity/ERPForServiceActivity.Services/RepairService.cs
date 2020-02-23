﻿using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MatBlazor;
using Google.Cloud.Storage;
using Google.Cloud.Vision.V1;
using Google.Cloud.Firestore;
using ERPForServiceActivity.Data;
using ERPForServiceActivity.Security;
using ERPForServiceActivity.Models.Repairs;
using ERPForServiceActivity.Services.Interfaces;
using ERPForServiceActivity.CommonModels.ViewModels.Repairs;
using ERPForServiceActivity.CommonModels.BindingModels.Repairs;

namespace ERPForServiceActivity.Services {
	public class RepairService : IRepairService {
		private ConnectionConfig connection = new ConnectionConfig();

		public async void UploadRepair(
			string serviceName, 
			AddRepairBindingModel repair) {
			
			FirestoreDb db = connection.GetFirestoreDb();

			CollectionReference repairsColRef = db
				.Collection("service-repairs");

			DateTime endOfWarranty = new DateTime(
				repair.BoughtAt.Year + repair.WarrantyPeriod / 12,
				repair.BoughtAt.Month, repair.BoughtAt.Day);

			repair.InWarranty = 
				DateTime.UtcNow >= repair.BoughtAt &&
				DateTime.UtcNow <= endOfWarranty ? true : false;

			Repair repairModel = new Repair(repair);

			await db
				.RunTransactionAsync(async transaction => {
					UpdateRepairId(serviceName, 
						repairModel.RepairId);
					
					await repairsColRef.AddAsync(repairModel);
				});
		}

		private async Task<string> GetDocumentId(string collectionName,
			string serviceName) {

			FirestoreDb db = connection.GetFirestoreDb();

			CollectionReference colRef = db
				.Collection(collectionName);

			Query query = colRef
				.WhereEqualTo("ServiceName", serviceName);

			string docId = string.Empty;
			QuerySnapshot snapshot = await query.GetSnapshotAsync();

			foreach (DocumentSnapshot ds in snapshot.Documents) {
				if (ds.Exists) {
					docId = ds.Id;
				}
			}

			return docId;
		}

		private async void UpdateRepairId(string serviceName, int id) {
			FirestoreDb db = connection.GetFirestoreDb();
			string docId = GetDocumentId("last-id-repairs", serviceName).Result;

			DocumentReference docRef = db
				.Collection("last-id-repairs")
				.Document(docId);

			await db.RunTransactionAsync(async transaction => {
				await docRef.UpdateAsync("Id", id);
			});
		}

		public async Task<int> GetLastId(string serviceName) {
			FirestoreDb db = connection.GetFirestoreDb();
			int id = int.MinValue;

			Query query = db
				.Collection("last-id-repairs")
				.WhereEqualTo("ServiceName", serviceName);

			QuerySnapshot qs = await query.GetSnapshotAsync();

			foreach (DocumentSnapshot ds in qs.Documents) {
				if (ds.Exists) {
					id = ds.GetValue<int>("Id");
				}
			}

			return id;
		}

		private RepairViewModel NewModel(DocumentSnapshot ds) {
			return new RepairViewModel() {
				RepairId = ds.GetValue<int>("RepairId"),
				RepairStatus = ds.GetValue<string>("RepairStatus"),
				CreatedAt = ds.GetValue<DateTime>("CreatedAt"),
				CustomerName = ds.GetValue<string>("CustomerName"),
				CustomerAddress = ds.GetValue<string>("CustomerAddress"),
				CustomerPhoneNumber = ds.GetValue<string>("CustomerPhoneNumber"),
				DefectByCustomer = ds.GetValue<string>("DefectByCustomer"),
				GoingToAddress = ds.GetValue<bool>("GoingToAddress"),
				InWarranty = ds.GetValue<bool>("InWarranty"),
				ApplianceBrand = ds.GetValue<string>("ApplianceBrand"),
				ApplianceType = ds.GetValue<string>("ApplianceType"),
				ApplianceModel = ds.GetValue<string>("ApplianceModel"),
				ApplianceSerialNumber = ds.GetValue<string>("ApplianceSerialNumber"),
				ApplianceProductCodeOrImei = ds.GetValue<string>("ApplianceProductCodeOrImei"),
				ApplianceEquipment = ds.GetValue<string>("ApplianceEquipment"),
				BoughtFrom = ds.GetValue<string>("BoughtFrom"),
				WarrantyCardNumber = ds.GetValue<string>("WarrantyCardNumber"),
				WarrantyPeriod = ds.GetValue<int>("WarrantyPeriod"),
				BoughtAt = ds.GetValue<DateTime>("BoughtAt"),
				AdditionalInformation = ds.GetValue<string>("AdditionalInformation")
			};
		}

		public async Task<List<RepairViewModel>>
			GetAllRepairs(string serviceName) {
			
			ConnectionConfig config = new ConnectionConfig();
			FirestoreDb db = config.GetFirestoreDb();
			List<RepairViewModel> repairs = new List<RepairViewModel>();

			QuerySnapshot snapshot = await db
				.Collection("service-repairs")
				.GetSnapshotAsync();

			Parallel.ForEach(snapshot.Documents, ds => {
				if (ds.Exists) {
					RepairViewModel model = NewModel(ds);

					repairs.Add(model);
				}
			});

			return repairs
				.OrderBy(x => x.RepairId)
				.ToList();
		}

		public ResultFromOCRBindingModel GetData(
			ResultFromOCRBindingModel model, IMatFileUploadEntry file) {
			
			ResultFromOCRBindingModel result = 
				new ResultFromOCRBindingModel();

			Regex snRegex = SerialNumberRegexes
				.GetSNRegex(model.ApplianceBrand);

			Regex modelRegex = LGModels
				.GetModelRegex(model.ApplianceType);
			
			ImageAnnotatorClient client = 
				ImageAnnotatorClient.Create();

			MemoryStream stream = new MemoryStream();
			file.WriteToStreamAsync(stream);

			Image image = 
				Image.FromStream(stream);

			var annotations = client.DetectText(image);

			foreach (var annotation in annotations) {
				if(snRegex.Match(annotation.Description)
					.Success) {

					result.ApplianceSerialNumber = 
						annotation.Description;
				}
				else if(modelRegex.Match(annotation.Description)
					.Success) {

					result.ApplianceModel = annotation.Description;
				}
			}

			return result;
		}

		public async void UploadLog(RepairLog log) {
			LogService service = new LogService();
			await service.UploadLog(log);
		}
	}
}