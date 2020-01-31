using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Google.Cloud.Firestore;
using ERPForServiceActivity.Data;
using ERPForServiceActivity.Models.Warehouse;
using ERPForServiceActivity.Services.Interfaces;
using ERPForServiceActivity.CommonModels.ViewModels.Warehouse;
using ERPForServiceActivity.CommonModels.BindingModels.WarehouseParts;

namespace ERPForServiceActivity.Services {
	public class WarehousePartService : IWarehousePartService {
		private ConnectionConfig connection = new ConnectionConfig();

		public async void AddWarehousePart(AddWarehousePartBindingModel model,
			string serviceName) {

			FirestoreDb db = connection.GetFirestoreDb();

			WarehousePart newPart = new WarehousePart() {
				PartNumber = model.PartNumber,
				Availability = model.Availability,
				Brand = model.Brand,
				Description = model.Description,
				Model = model.Model,
				Price = model.Price,
				SubstituteParts = model.SubstituteParts,
				Invoice = model.Invoice,
				InvoiceDate = model.InvoiceDate.ToUniversalTime(),
				ReceivedDate = DateTime.UtcNow.ToUniversalTime()
			};

			CollectionReference colRef = db
				.Collection("warehouse-parts")
				.Document("bcyvKBFBWE6DxnvIQ1Kn")
				.Collection("parts");

			await db.RunTransactionAsync(async transaction => {
				await colRef.AddAsync(newPart);
			});
		}

		public async Task<List<WarehousePartViewModel>> 
			GetAllParts(string serviceName) {
			
			FirestoreDb db = connection.GetFirestoreDb();
			List<WarehousePartViewModel> parts = 
				new List<WarehousePartViewModel>();

			Query query = db.Collection("warehouse-parts")
				.Document("bcyvKBFBWE6DxnvIQ1Kn")
				.Collection("parts")
				.WhereGreaterThanOrEqualTo("Availability", 1);

			QuerySnapshot snapshot = await query.GetSnapshotAsync();
			foreach(DocumentSnapshot ds in snapshot.Documents) {
				if(ds.Exists) {
					WarehousePartViewModel part = ds
						.ConvertTo<WarehousePartViewModel>();

					parts.Add(part);
				}
			}

			return parts;
		}
	}
}
