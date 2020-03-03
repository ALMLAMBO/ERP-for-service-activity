using System;
using System.IO;
using System.Linq;
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
using ERPForServiceActivity.Models.Warehouse;
using ERPForServiceActivity.Services.Interfaces;
using ERPForServiceActivity.CommonModels.ViewModels.Repairs;
using ERPForServiceActivity.CommonModels.BindingModels.Repairs;
using ERPForServiceActivity.CommonModels.BindingModels.WarehouseParts;

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

			RepairLog log = new RepairLog() {
				TimeOfEvent = DateTime.UtcNow,
				RepairId = repairModel.RepairId,
				TypeOfEvent = "create",
				Status = repairModel.RepairStatus,
				Description = $"Add repair with id {repairModel.RepairId}"
			};

			UploadLog(log);
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

		public Task<ResultFromOCRBindingModel> GetData() {
			Environment.SetEnvironmentVariable(
				"GOOGLE_APPLICATION_CREDENTIALS", 
				CommonSecurityConstants.PathToGoogleCloudJson);

			ResultFromOCRBindingModel result = 
				new ResultFromOCRBindingModel();

			Regex snRegex = SerialNumberRegexes
				.GetSNRegex("LG");

			Regex modelRegex = UnitModels
				.GetModelRegex(
					"LG", 
					"TV");
			
			ImageAnnotatorClient client = 
				ImageAnnotatorClient.Create();

			Image image = Image
				.FromFile(
					@"E:\ALEKS\Images\pictures-diploma-project\1.jpg");

			IReadOnlyList<EntityAnnotation> annotations =
				client.DetectText(image);

			foreach(EntityAnnotation annotation in annotations) {
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

			return Task.FromResult(result);
		}

		public async void UploadLog(RepairLog log) {
			LogService service = new LogService();
			await service.UploadLog(log);
		}

		public void UpdateStatus(string status, int id) {
			FirestoreDb db = connection.GetFirestoreDb();
			QuerySnapshot snapshot = db
				.Collection("service-repairs")
				.WhereEqualTo("RepairId", id)
				.Limit(1)
				.GetSnapshotAsync()
				.Result;

			snapshot.Documents
				.FirstOrDefault()
				.Reference.UpdateAsync("RepairStatus", status);
		}

		public async void UpdateRepair(RepairViewModel model) {
			FirestoreDb db = connection.GetFirestoreDb();

			QuerySnapshot snapshot = db
				.Collection("service-repairs")
				.WhereEqualTo("RepairId", model.RepairId)
				.Limit(1)
				.GetSnapshotAsync()
				.Result;

			Repair repair = snapshot
				.FirstOrDefault()
				.ConvertTo<Repair>();

			repair = NewRepair(model);
			repair.Notes = model.Notes;

			Dictionary<string, object> d = repair
				.GetType()
				.GetProperties()
				.ToDictionary(x => x.Name, x => x.GetValue(repair, null));

			string logDesc = "Update repair card";

			await snapshot.Documents
				.FirstOrDefault()
				.Reference
				.UpdateAsync(d);

			//modelAsDict
			//	.ToList()
			//	.ForEach(x => {
			//		if(repairAsDict.ContainsKey(x.Key)) {
			//			if(repairAsDict[x.Key] != x.Value) {
			//				logDesc += $"\\n{x.Key} from {repairAsDict[x.Key]} to {x.Value}";
			//			}
			//		}
			//	});

			RepairLog log = new RepairLog() {
				TimeOfEvent = DateTime.UtcNow,
				Description = logDesc,
				TypeOfEvent = "update"
			};

			await new LogService()
				.UploadLogToExistingRepair(model.RepairId, log);
		}

		private Repair NewRepair(RepairViewModel model) {
			return new Repair() {
				RepairId = model.RepairId,
				RepairStatus = model.RepairStatus,
				CreatedAt = model.CreatedAt,
				CustomerName = model.CustomerName,
				CustomerAddress = model.CustomerAddress,
				CustomerPhoneNumber = model.CustomerPhoneNumber,
				DefectByCustomer = model.DefectByCustomer,
				GoingToAddress = model.GoingToAddress,
				InWarranty = model.InWarranty,
				ApplianceBrand = model.ApplianceBrand,
				ApplianceType = model.ApplianceType,
				ApplianceModel = model.ApplianceModel,
				ApplianceSerialNumber = model.ApplianceSerialNumber,
				ApplianceProductCodeOrImei = model.ApplianceProductCodeOrImei,
				ApplianceEquipment = model.ApplianceEquipment,
				BoughtFrom = model.BoughtFrom,
				WarrantyCardNumber = model.WarrantyCardNumber,
				WarrantyPeriod = model.WarrantyPeriod,
				BoughtAt = model.BoughtAt,
				AdditionalInformation = model.AdditionalInformation
			};
		}

		public void AddPartToRepair(string partNumber, int id) {
			throw new NotImplementedException();
		}

		public async void AddRequestedPartToRepair(string partNumber, int id) {
			FirestoreDb db = connection.GetFirestoreDb();
			QuerySnapshot snapshot = db
				.Collection("repair-parts")
				.WhereEqualTo("RepairId", id)
				.GetSnapshotAsync()
				.Result;

			if(snapshot.Count == 0) {
				RequestPartBindingModel requestPart = new RequestPartBindingModel() {
					RepairId = id,
					PartsForRepair = new Dictionary<string, int>() {
						{ partNumber, 1 }
					}
				};

				CollectionReference colRef = db
					.Collection("repair-parts");

				await db.RunTransactionAsync(async t => {
					await colRef.AddAsync(requestPart);
				});

				RepairLog log = new RepairLog() {
					TimeOfEvent = DateTime.UtcNow,
					TypeOfEvent = "request part",
					Description = $"Request part with part number {partNumber}"
				};

				await new LogService()
					.UploadLogToExistingRepair(id, log);
			}
			else {
				RequestPartBindingModel model = snapshot
					.FirstOrDefault()
					.ConvertTo<RequestPartBindingModel>();

				if(model.PartsForRepair.ContainsKey(partNumber)) {
					++model.PartsForRepair[partNumber];
				}
				else {
					model.PartsForRepair.Add(partNumber, 1);
				}

				await snapshot
					.FirstOrDefault()
					.Reference
					.UpdateAsync("PartsForRepair", model.PartsForRepair);

				RepairLog log = new RepairLog() {
					TimeOfEvent = DateTime.UtcNow,
					TypeOfEvent = "update part qnt",
					Description = $"Update part qnt for {partNumber}"
				};

				await new LogService()
					.UploadLogToExistingRepair(id, log);
			}
		}

		public async void SendPartToRepair(int id, string partNumber, int qnt) {
			FirestoreDb db = connection.GetFirestoreDb();

			CollectionReference colRef = db
				.Collection("warehouse-parts")
				.Document("bcyvKBFBWE6DxnvIQ1Kn")
				.Collection("parts");

			QuerySnapshot snapshot = colRef
				.WhereEqualTo("PartNumber", partNumber)
				.GetSnapshotAsync()
				.Result;

			if(snapshot.Count == 0) {
				return;
			}
			else {
				WarehousePart part = new List<DocumentSnapshot>
					(snapshot.Documents)
					.OrderByDescending(x => x.CreateTime)
					.FirstOrDefault()
					.ConvertTo<WarehousePart>();

				if(part.Availability < qnt) {
					return;
				}
				else {
					snapshot.Documents
						.ToList()
						.ForEach(async x => {
							WarehousePart p = x.ConvertTo<WarehousePart>();
							p.Availability -= qnt;

							await x
								.Reference
								.UpdateAsync("Availability", p.Availability);
						});

					QuerySnapshot qs = db
						.Collection("repair-parts")
						.WhereEqualTo("RepairId", id)
						.Limit(1)
						.GetSnapshotAsync()
						.Result;

					RequestPartBindingModel parts = qs
						.Documents
						.FirstOrDefault()
						.ConvertTo<RequestPartBindingModel>();

					parts.PartsForRepair[partNumber] = qnt;

					await qs.Documents
						.FirstOrDefault()
						.Reference
						.UpdateAsync("PartsForRepair", parts.PartsForRepair);

					RepairLog log = new RepairLog() {
						TimeOfEvent = DateTime.UtcNow,
						TypeOfEvent = "update part qnt",
						Description = "Update part qnt"
					};

					await new LogService()
						.UploadLogToExistingRepair(id, log);
				}
			}
		}

		public Dictionary<string, int> GetPartsForRepair(int id) {
			FirestoreDb db = connection.GetFirestoreDb();

			QuerySnapshot snapshot = db
				.Collection("repair-parts")
				.WhereEqualTo("RepairId", id)
				.Limit(1)
				.GetSnapshotAsync()
				.Result;

			return snapshot
				.Documents
				.FirstOrDefault()
				.ConvertTo<RequestPartBindingModel>()
				.PartsForRepair;
		}

		public Task<StatusResult> GetRepairStatus(string name, string reclaim) {
			FirestoreDb db = connection.GetFirestoreDb();
			StatusResult result = new StatusResult();

			string repairNum = reclaim
				.Substring(reclaim.LastIndexOf("0") + 1);

			int id = int.Parse(repairNum);

			QuerySnapshot snapshot = db
				.Collection("service-repairs")
				.WhereEqualTo("CustomerName", name)
				.GetSnapshotAsync()
				.Result;

			result.Status = snapshot.FirstOrDefault()
				.ConvertTo<Repair>()
				.RepairStatus;

			QuerySnapshot qs = db.Collection("activity-log")
				.WhereEqualTo("RepairId", id)
				.GetSnapshotAsync()
				.Result;

			string docId = qs.FirstOrDefault().Id;
			QuerySnapshot getLog = db
				.Collection("activity-log")
				.Document(docId)
				.Collection("logs")
				.GetSnapshotAsync()
				.Result;

			result.Time = getLog
				.Where(x => x.ConvertTo<RepairLog>()
					.Description.Contains(result.Status))
				.OrderByDescending(x => x.CreateTime)
				.FirstOrDefault()
				.ConvertTo<RepairLog>()
				.TimeOfEvent;

			return Task.FromResult(result);
		}
	}
}