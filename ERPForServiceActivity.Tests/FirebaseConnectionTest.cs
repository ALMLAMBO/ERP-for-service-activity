using System;
using Xunit;
using Google.Cloud.Firestore;
using ERPForServiceActivity.Data;

namespace ERPForServiceActivity.Tests {
	public class FirebaseConnectionTest {
		[Fact]
		public async void TestConnection() {
			ConnectionConfig config = new ConnectionConfig();
			FirestoreDb database = config.GetFirestoreDb();
			Query query = database.Collection("parts");
			QuerySnapshot qs = await query.GetSnapshotAsync();

			Assert.NotEqual(0, qs.Count);

			Query query1 = database.Collection("licenses");
			QuerySnapshot qs1 = await query.GetSnapshotAsync();

			Assert.NotEqual(0, qs1.Count);

			Query query2 = database.Collection("repairs");
			QuerySnapshot qs2 = await query.GetSnapshotAsync();

			Assert.NotEqual(0, qs2.Count);
		}
	}
}
