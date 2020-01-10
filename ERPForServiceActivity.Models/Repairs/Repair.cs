using System;
using System.ComponentModel.DataAnnotations;
using BlazorInputFile;
using Google.Cloud.Firestore;

namespace ERPForServiceActivity.Models.Repairs {
	[FirestoreData]
	public class Repair {
		public string Id { get; set; }

		[Required]
		[FirestoreProperty]
		public int RepairId { get; set; }

		[Required]
		[FirestoreProperty]
		public string RepairStatus { get; set; }

		[Required]
		[FirestoreProperty]
		public string CustomerName { get; set; }

		[Required]
		[FirestoreProperty]
		public string CustomerAddress { get; set; }

		[Required]
		[FirestoreProperty]
		public string CustomerPhoneNumber { get; set; }

		[Required]
		[FirestoreProperty]
		public string DefectByCustomer { get; set; }

		[Required]
		[FirestoreProperty]
		public bool GoingToAddress { get; set; }

		[Required]
		[FirestoreProperty]
		public bool InWarranty { get; set; }

		[Required]
		[FirestoreProperty]
		public string ApplianceBrand { get; set; }

		[Required]
		[FirestoreProperty]
		public string ApplianceType { get; set; }

		[Required]
		[FirestoreProperty]
		public string ApplianceModel { get; set; }

		[Required]
		[FirestoreProperty]
		public string ApplianceSerialNumber { get; set; }

		[Required]
		[FirestoreProperty]
		public string ApplianceProductCodeOrImei { get; set; }

		[Required]
		[FirestoreProperty]
		public string ApplianceEquipment { get; set; }

		[Required]
		[FirestoreProperty]
		public string BoughtFrom { get; set; }

		[Required]
		[FirestoreProperty]
		public string WarrantyCardNumber { get; set; }

		[Required]
		[FirestoreProperty]
		public int WarrantyPeriod { get; set; }

		[Required]
		[FirestoreProperty]
		[DataType(DataType.Date)]
		public DateTime BoughtAt { get; set; }

		[FirestoreProperty]
		public string AdditionalInformation { get; set; }
	}
}
