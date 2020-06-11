using System.Threading.Tasks;
using Google.Cloud.Firestore;
using Google.Apis.Auth.OAuth2;
using ERPForServiceActivity.Security;

namespace ERPForServiceActivity.Data {
	public class DatabaseConnection {
		private FirestoreDb database;

		private async Task Setup() {
			await GoogleCredential
				.FromFileAsync(
					CommonSecurityConstants.PathToFirestoreJson,
					default);

			database = await FirestoreDb
				.CreateAsync(CommonSecurityConstants.ProjectId);
		}

		public async Task<FirestoreDb> GetFirestoreDb() {
			await Setup();

			return database;
		}
	}
}
