﻿using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Google.Cloud.Firestore;
using ERPForServiceActivity.Data;
using ERPForServiceActivity.Models.Repairs;
using ERPForServiceActivity.Services.Interfaces;
using ERPForServiceActivity.CommonModels.BindingModels.Repairs;
using ERPForServiceActivity.CommonModels.ViewModels.Repairs;

namespace ERPForServiceActivity.Services {
	public class RepairService : IRepairInterface {
		private ConnectionConfig connection = new ConnectionConfig();

		public async void UploadRepair(string serviceName, AddRepairBindingModel repair) {
			FirestoreDb db = connection.GetFirestoreDb();
			int repairId = GetLastId(serviceName).Result;
			++repairId;

			CollectionReference colRef = db
				.Collection("service-repairs");

			Query query = colRef
				.WhereEqualTo("ServiceName", serviceName);

			string docId = string.Empty;
			QuerySnapshot snapshot = await query.GetSnapshotAsync();

			foreach (DocumentSnapshot ds in snapshot.Documents) {
				if(ds.Exists) {
					docId = ds.Id;
				}
			}

			CollectionReference repairsColRef = db
				.Collection("service-repairs")
				.Document(docId)
				.Collection("repairs");

			Repair repairModel = new Repair(repair);
			repairModel.RepairId = repairId;

			UpdateRepairId(serviceName, repairId);

			await db.RunTransactionAsync(async transaction => {
				await repairsColRef.AddAsync(repairModel);
			});
		}

		private async void UpdateRepairId(string serviceName, int id) {
			FirestoreDb db = connection.GetFirestoreDb();
			Query query = db
				.Collection("last-id-repairs")
				.WhereEqualTo("ServiceName", serviceName);

			QuerySnapshot qs = await query.GetSnapshotAsync();
			string docId = string.Empty;

			foreach (DocumentSnapshot ds in qs.Documents) {
				if(ds.Exists) {
					docId = ds.Id;
				}
			}

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

		public async Task<List<RepairViewModel>> GetAllRepairs(string serviceName) {
			ConnectionConfig config = new ConnectionConfig();
			FirestoreDb db = config.GetFirestoreDb();
			List<RepairViewModel> repairs = new List<RepairViewModel>();

			Query query = db.Collection("service-repairs")
				.Document("kk5M3Pl4Zvme6db7kn7p")
				.Collection("repairs");

			QuerySnapshot snapshot = await query.GetSnapshotAsync();

			foreach (DocumentSnapshot ds in snapshot.Documents) {
				if(ds.Exists) {
					RepairViewModel model = new RepairViewModel() {
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

					repairs.Add(model);
				}
			}

			return repairs
				.OrderBy(x => x.RepairId)
				.ToList();
		}
	}
}