using System;
using Google.Cloud.Firestore;
using ERPForServiceActivity.Security;

namespace ERPForServiceActivity.Data {
	public class ConnectionConfig {
		private FirestoreDb database;
		private string projectId;

		private void SetUp() {
			string filepath = CommonSecurityConstants.PathToFirestoreJson;
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