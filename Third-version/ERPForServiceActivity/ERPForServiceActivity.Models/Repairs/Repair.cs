using System;
using System.ComponentModel.DataAnnotations;
using FoolProof.Core;
using Google.Cloud.Firestore;

namespace ERPForServiceActivity.Models.Repairs {
	[FirestoreData]
	public class Repair {
		[FirestoreDocumentId]
		public string Id { get; set; }

		[Required]
		[FirestoreProperty]
		public int RepairId { get; set; }

		[Required]
		[FirestoreProperty]
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

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

		[FirestoreProperty]
		public string TechnicianName { get; set; } = string.Empty;

		[FirestoreProperty]
		public double TechnicianLabor { get; set; }

		[Required]
		[MaxLength(15)]
		public string UnitType { get; set; }

		[MaxLength(20)]
		[RequiredIf("UnitType", Operator.NotEqualTo, "Mobile Phone")]
		public string UnitModel { get; set; }

		[MaxLength(30)]
		[RequiredIf("UnitType", Operator.NotEqualTo, "Mobile Phone")]
		public string UnitSerialNumber { get; set; }

		[MaxLength(30)]
		[RequiredIf("UnitType", Operator.EqualTo, "Mobile Phone")]
		public string UnitProductCodeOrImei { get; set; }

		[Required]
		[MaxLength(150)]
		public string UnitEquipment { get; set; }

		[Required]
		[MaxLength(30)]
		public string BoughtFrom { get; set; }

		[Required]
		[MaxLength(20)]
		public string WarrantyCardNumber { get; set; }

		[Required]
		public int WarrantyPeriod { get; set; }

		[Required]
		[DataType(DataType.Date)]
		public DateTime BoughtAt { get; set; }

		[MaxLength(500)]
		public string AdditionalInformation { get; set; }

		[Required]
		public bool Cancelled { get; set; }

		[FirestoreProperty]
		public string Notes { get; set; } = string.Empty;
	}
}
