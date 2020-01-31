using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Google.Cloud.Firestore;

namespace ERPForServiceActivity.Models.Warehouse {
	[FirestoreData]
	public class WarehousePart {
		public string Id { get; set; }

		[Required]
		[FirestoreProperty]
		public string PartNumber { get; set; }

		[Required]
		[FirestoreProperty]
		public int Availability { get; set; }

		[Required]
		[FirestoreProperty]
		public string Model { get; set; }

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