using System.Threading.Tasks;
using Google.Cloud.Firestore;
using ERPForServiceActivity.Data;
using ERPForServiceActivity.Models.Repairs;
using ERPForServiceActivity.Services.Interfaces;
using ERPForServiceActivity.CommonModels.BindingModels.Repairs;

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

			Repair repairModel = new Repair(repair);

			await db.RunTransactionAsync(async transaction => {
				await repairsColRef.AddAsync(repairModel);
			});

			UpdateRepairId(serviceName, repair.RepairId);
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

		private async Task<int> GetLastId(string serviceName) {
			FirestoreDb db = connection.GetFirestoreDb();
			int id = int.MinValue;

			Query query = db
				.Collection("last-id-repairs")
				.WhereEqualTo("ServiceName", serviceName);

			QuerySnapshot qs = await query.GetSnapshotAsync();
			string docId = string.Empty;

			foreach (DocumentSnapshot ds in qs.Documents) {
				if (ds.Exists) {
					docId = ds.Id;
					id = ds.GetValue<int>("Id");
				}
			}

			DocumentReference docRef = db
				.Collection("last-id-repairs")
				.Document(docId);

			return id;
		}
	}
}