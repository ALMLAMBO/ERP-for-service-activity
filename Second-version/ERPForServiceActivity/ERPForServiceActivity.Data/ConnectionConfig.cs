using System;
using Google.Cloud.Firestore;
using Google.Apis.Auth.OAuth2;
using ERPForServiceActivity.Security;

namespace ERPForServiceActivity.Data {
	public class ConnectionConfig {
		private FirestoreDb database;
		private string projectId;

		private void SetUp() {
			GoogleCredential.FromFile(
				CommonSecurityConstants
					.PathToFirestoreJson);

			projectId = CommonSecurityConstants.ProjectId;
			database = FirestoreDb.Create(projectId);
		}
		
		public FirestoreDb GetFirestoreDb() {
			SetUp();

			return database;
		}
	}
}