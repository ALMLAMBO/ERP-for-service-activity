using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Google.Cloud.Firestore;
using ERPForServiceActivity.CommonModels.BindingModels.WarehouseParts;

namespace ERPForServiceActivity.Models.Warehouse {
	[FirestoreData]
	public class WarehousePart {
		public WarehousePart() {

		}

		public WarehousePart(AddWarehousePartBindingModel model) {
			PartNumber = model.PartNumber;
			Availability = model.Availability;
			Brand = model.Brand;
			Description = model.Description;
			Model = model.Model;
			Price = model.Price;
			SubstituteParts = model.SubstituteParts;
			Invoice = model.Invoice;
			InvoiceDate = model.InvoiceDate.ToUniversalTime();
			ReceivedDate = DateTime.UtcNow.ToUniversalTime();
		}

		public string Id { get; set; }

		[Required]
		[FirestoreProperty]
		public string PartNumber { get; set; }

		[Required]
		[FirestoreProperty]
		public int Availability { get; set; }

		[Required]
		[FirestoreProperty]
		public List<string> Model { get; set; }

		[Required]
		[FirestoreProperty]
		public string Description { get; set; }

		[Required]
		[FirestoreProperty]
		public string Brand { get; set; }

		[FirestoreProperty]
		public List<string> SubstituteParts { get; set; }

		[Required]
		[FirestoreProperty]
		public double Price { get; set; }

		[Required]
		[FirestoreProperty]
		public string Invoice { get; set; }

		[Required]
		[FirestoreProperty]
		public DateTime InvoiceDate { get; set; }

		[Required]
		[FirestoreProperty]
		public DateTime ReceivedDate { get; set; }
	}
}