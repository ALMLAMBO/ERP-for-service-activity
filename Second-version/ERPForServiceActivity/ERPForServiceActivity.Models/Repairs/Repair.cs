using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Google.Cloud.Firestore;
using ERPForServiceActivity.CommonModels.BindingModels.Repairs;

namespace ERPForServiceActivity.Models.Repairs {
	[FirestoreData]
	public class Repair {
		public Repair() {

		}

		public Repair(AddRepairBindingModel repair) {
			RepairId = repair.RepairId;
			RepairStatus = repair.Cancelled ? 
				"Cancelled" : "Created repair";
			
			CreatedAt = DateTime.UtcNow;
			CustomerName = repair.CustomerName;
			CustomerAddress = repair.CustomerAddress;
			CustomerPhoneNumber = repair.CustomerPhoneNumber;
			DefectByCustomer = repair.DefectByCustomer;
			GoingToAddress = repair.GoingToAddress;
			InWarranty = repair.InWarranty;
			ApplianceBrand = repair.ApplianceBrand;
			ApplianceType = repair.ApplianceType;
			ApplianceModel = repair.ApplianceModel;
			ApplianceSerialNumber = repair.ApplianceSerialNumber;
			ApplianceProductCodeOrImei = repair.ApplianceProductCodeOrImei;
			ApplianceEquipment = repair.ApplianceEquipment;
			BoughtFrom = repair.BoughtFrom;
			WarrantyCardNumber = repair.WarrantyCardNumber;
			WarrantyPeriod = repair.WarrantyPeriod;
			BoughtAt = repair.BoughtAt;
			AdditionalInformation = repair.AdditionalInformation;
		}

		public string Id { get; set; }

		[Required]
		[FirestoreProperty]
		public int RepairId { get; set; }

		[Required]
		[FirestoreProperty]
		public DateTime CreatedAt { get; set; }

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

		[FirestoreProperty]
		public double PartsPrice { get; set; }

		[Required]
		[FirestoreProperty]
		public string ApplianceBrand { get; set; }

		[Required]
		[FirestoreProperty]
		public string ApplianceType { get; set; }

		[MaxLength(20)]
		[FirestoreProperty]
		public string ApplianceModel { get; set; }

		[MaxLength(30)]
		[FirestoreProperty]
		public string ApplianceSerialNumber { get; set; }

		[MaxLength(30)]
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

		[FirestoreProperty]
		public string Notes { get; set; }
	}
}
