using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MatBlazor;
using BlazorInputFile;
using ERPForServiceActivity.CommonModels.Attributes;

namespace ERPForServiceActivity.CommonModels.BindingModels.Repairs {
	public class AddRepairBindingModel {
		[Required]
		public int RepairId { get; set; }

		[Required]
		[MaxLength(30)]
		[RegularExpression(".*[a-zA-Zа-яА-Я].*")]
		public string CustomerName { get; set; }

		[Required]
		[MaxLength(100)]
		public string CustomerAddress { get; set; }
		
		[Required]
		[MaxLength(15)]
		[RegularExpression(".*[0-9].*")]
		public string CustomerPhoneNumber { get; set; }

		[Required]
		[MaxLength(100)]
		public string DefectByCustomer { get; set; }

		[Required]
		public bool GoingToAddress { get; set; }

		[Required]
		public bool InWarranty { get; set; }

		[Required]
		[MaxLength(15)]
		public string ApplianceBrand { get; set; }

		[Required]
		[MaxLength(15)]
		public string ApplianceType { get; set; }

		[MaxLength(20)]
		[ConditionalRequired]
		public string ApplianceModel { get; set; }

		[MaxLength(30)]
		[ConditionalRequired]
		public string ApplianceSerialNumber { get; set; }

		[MaxLength(30)]
		[ConditionalRequired]
		public string ApplianceProductCodeOrImei { get; set; }

		[Required]
		[MaxLength(150)]
		public string ApplianceEquipment { get; set; }

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

		public bool Cancelled { get; set; }
	}
}