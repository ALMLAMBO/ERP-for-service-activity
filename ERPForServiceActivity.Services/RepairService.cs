using ERPForServiceActivity.CommonModels.BindingModels.Repairs;
using ERPForServiceActivity.Data;
using ERPForServiceActivity.Models.Repairs;
using ERPForServiceActivity.Services.Interfaces;
using Google.Cloud.Firestore;

namespace ERPForServiceActivity.Services {
	public class RepairService : IRepairInterface {
		private ConnectionConfig connection = new ConnectionConfig();

		public async void UploadRepair(string serviceName, AddRepairBindingModel repair) {
			FirestoreDb db = connection.GetFirestoreDb();

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

			Repair repairModel = new Repair() {
				RepairId = repair.RepairId,
				RepairStatus = "created",
				CustomerName = repair.CustomerName,
				CustomerAddress = repair.CustomerAddress,
				CustomerPhoneNumber = repair.CustomerPhoneNumber,
				DefectByCustomer = repair.DefectByCustomer,
				GoingToAddress = repair.GoingToAddress,
				InWarranty = true, // TODO: change it get from repair
				ApplianceBrand = repair.ApplianceBrand,
				ApplianceType = repair.ApplianceType,
				ApplianceModel = repair.ApplianceModel,
				ApplianceSerialNumber = repair.ApplianceSerialNumber,
				ApplianceProductCodeOrImei = repair.ApplianceProductCodeOrImei,
				ApplianceEquipment = repair.ApplianceEquipment,
				BoughtFrom = repair.BoughtFrom,
				WarrantyCardNumber = repair.WarrantyCardNumber,
				WarrantyPeriod = repair.WarrantyPeriod,
				BoughtAt = repair.BoughtAt,
				AdditionalInformation = repair.AdditionalInformation
			};

			await repairsColRef.AddAsync(repairModel);
		}
	}
}
