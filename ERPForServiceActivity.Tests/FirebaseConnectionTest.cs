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

			Assert.NotNull(qs);

			Query query1 = database.Collection("licenses");
			QuerySnapshot qs1 = await query1.GetSnapshotAsync();

			Assert.NotNull(qs1);

			Query query2 = database.Collection("service-repairs");
			QuerySnapshot qs2 = await query2.GetSnapshotAsync();

			Assert.NotNull(qs2);
		}

		[Fact]
		public async void CheckServiceRepairsNestedCollections() {
			ConnectionConfig config = new ConnectionConfig();
			FirestoreDb database = config.GetFirestoreDb();
			
			Query q1 = database.Collection("service-repairs");
			QuerySnapshot qs1 = await q1.GetSnapshotAsync();

			Assert.NotNull(qs1);

			Query q2 = database.Collection("service-repairs")
				.Document("kk5M3Pl4Zvme6db7kn7p")
				.Collection("repairs");

			QuerySnapshot qs2 = await q2.GetSnapshotAsync();

			Assert.NotNull(qs2);

			Query q3 = database.Collection("service-repairs")
				.Document("kk5M3Pl4Zvme6db7kn7p")
				.Collection("repairs")
				.Document("9iXz590oBLwVGhjCYr1K")
				.Collection("parts");

			QuerySnapshot qs3 = await q3.GetSnapshotAsync();

			Assert.NotNull(qs3);
		}
	}
}
