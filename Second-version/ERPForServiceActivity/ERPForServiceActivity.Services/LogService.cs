using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Google.Cloud.Firestore;
using ERPForServiceActivity.Data;
using ERPForServiceActivity.Models.Repairs;
using ERPForServiceActivity.Services.Interfaces;

namespace ERPForServiceActivity.Services {
	public class LogService : ILogService {
		private ConnectionConfig connection = 
			new ConnectionConfig();

		public async Task UploadLog(RepairLog log) {
			FirestoreDb db = 
				connection.GetFirestoreDb();

			CollectionReference colRef = db
				.Collection("activity-log");

			DocumentReference docRef = null;

			Dictionary<string, object> repairIdDoc =
				new Dictionary<string, object>() {
					{ "RepairId", log.RepairId }
				};

			await db.RunTransactionAsync(async t => {
				docRef = await colRef.AddAsync(repairIdDoc);
			});

			CollectionReference subDocRef = 
				docRef.Collection("logs");

			await db.RunTransactionAsync(async t => {
				await subDocRef.AddAsync(log);
			});
		}

		public async Task<List<RepairLog>> 
			GetLogsForRepair(int id) {

			FirestoreDb db = connection.GetFirestoreDb();
			List<RepairLog> logs = new List<RepairLog>();

			QuerySnapshot getIdDoc = await db
				.Collection("activity-log")
				.GetSnapshotAsync();

			DocumentReference docRef = getIdDoc
				.FirstOrDefault(x => x.GetValue<int>("RepairId") == id)
				.Reference;

			QuerySnapshot getLogs = await docRef
				.Collection("logs")
				.GetSnapshotAsync();

			Parallel.ForEach(getLogs.Documents, ds => {
				logs.Add(ds.ConvertTo<RepairLog>());
			});

			return logs;
		}

		public async Task UploadLogToExistingRepair(int id, RepairLog log) {
			FirestoreDb db = connection.GetFirestoreDb();
			CollectionReference colRef = db
				.Collection("activity-log");

			QuerySnapshot snapshot = await colRef
				.WhereEqualTo("RepairId", id)
				.Limit(1)
				.GetSnapshotAsync();

			CollectionReference subColRef = snapshot
				.Documents
				.FirstOrDefault()
				.Reference
				.Collection("logs");

			await db.RunTransactionAsync(async t => {
				await subColRef.AddAsync(log);
			});
		}
	}
}
