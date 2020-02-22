using System;
using System.Text;
using System.Collections.Generic;
using Google.Cloud.Firestore;
using System.Threading.Tasks;
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

			await db.RunTransactionAsync(async t => {
				await colRef.AddAsync(log);
			});
		}

		public async Task<List<RepairLog>> 
			GetLogsForRepair(int id) {
			
			FirestoreDb db = connection
				.GetFirestoreDb();

			List<RepairLog> logs = new List<RepairLog>();

			CollectionReference colRef = db
				.Collection("activity-log");

			QuerySnapshot snapshot = await colRef
				.WhereEqualTo("RepairId", id)
				.GetSnapshotAsync();

			Parallel.ForEach(snapshot.Documents, ds => {
				logs.Add(ds.ConvertTo<RepairLog>());
			});

			return logs;
		}
	}
}
