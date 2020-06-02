using System;
using System.ComponentModel.DataAnnotations;
using FoolProof.Core;
using ERPForServiceActivity.Common;

namespace ERPForServiceActivity.CommonModels.BindingModels.Repairs {
	public class AddRepairBindingModel {
		[Required]
		public int RepairId { get; set; }

		[Required]
		[MaxLength(30, ErrorMessage = ErrorMessages.TooLong)]
		[RegularExpression(".*[a-zA-Zа-яА-Я].*")]
		public string CustomerName { get; set; }

		[Required]
		[MaxLength(100, ErrorMessage = ErrorMessages.TooLong)]
		public string CustomerAddress { get; set; }

		[Required]
		[MaxLength(15, ErrorMessage = ErrorMessages.TooLong)]
		[RegularExpression(".*[0-9].*", ErrorMessage = 
			ErrorMessages.InvalidPhoneNumber)]
		public string CustomerPhoneNumber { get; set; }

		[Required]
		[MaxLength(100, ErrorMessage = ErrorMessages.TooLong)]
		public string DefectByCustomer { get; set; }

		[Required]
		public bool GoingToAddress { get; set; }

		[Required]
		public bool InWarranty { get; set; }

		[Required]
		[MaxLength(15, ErrorMessage = ErrorMessages.TooLong)]
		public string UnitBrand { get; set; }

		[Required]
		[MaxLength(15, ErrorMessage = ErrorMessages.TooLong)]
		public string UnitType { get; set; }

		[MaxLength(20, ErrorMessage = ErrorMessages.TooLong)]
		[RequiredIf("UnitType", Operator.NotEqualTo, "Mobile Phone")]
		public string UnitModel { get; set; }

		[MaxLength(30, ErrorMessage = ErrorMessages.TooLong)]
		[RequiredIf("UnitType", Operator.NotEqualTo, "Mobile Phone")]
		public string UnitSerialNumber { get; set; }

		[MaxLength(30, ErrorMessage = ErrorMessages.TooLong)]
		[RequiredIf("UnitType", Operator.EqualTo, "Mobile Phone")]
		public string UnitProductCodeOrImei { get; set; }

		[Required]
		[MaxLength(150, ErrorMessage = ErrorMessages.TooLong)]
		public string UnitEquipment { get; set; }

		[Required]
		[MaxLength(30, ErrorMessage = ErrorMessages.TooLong)]
		public string BoughtFrom { get; set; }

		[Required]
		[MaxLength(20, ErrorMessage = ErrorMessages.TooLong)]
		public string WarrantyCardNumber { get; set; }

		[Required]
		public int WarrantyPeriod { get; set; }

		[Required]
		[DataType(DataType.Date)]
		public DateTime BoughtAt { get; set; }

		[MaxLength(500, ErrorMessage = ErrorMessages.TooLong)]
		public string AdditionalInformation { get; set; }

		[Required]
		public bool Cancelled { get; set; }
	}
}
