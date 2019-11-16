using System;
using System.Collections.Generic;
using System.Text;
using Google.Cloud.Firestore;

namespace ERPForServiceActivity.Data {
	public class ConnectionConfig {
		private FirestoreDb database;
		private string projectId;

		private void SetUp() {
			string filepath = @"E:\\Diploma-project\\ERP-for-service-activity\\ERPForServiceActivity.Data\\erp-for-service-activity-d0a7eb625242.json";
			Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
			projectId = "erp-for-service-activity";
			database = FirestoreDb.Create(projectId);
		}
		
		public FirestoreDb GetFirestoreDb() {
			SetUp();

			return database;
		}
	}
}