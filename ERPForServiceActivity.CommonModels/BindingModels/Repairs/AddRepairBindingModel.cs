using BlazorInputFile;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERPForServiceActivity.CommonModels.BindingModels.Repairs {
	public class AddRepairBindingModel {
		[Required]
		public int RepairId { get; set; }

		[Required]
		[MaxLength(30)]
		[RegularExpression("[a-z][A-Z][а-я][А-Я]")]
		public string CustomerName { get; set; }

		[Required]
		[MaxLength(100)]
		public string CustomerAddress { get; set; }
		
		[Required]
		[MaxLength(15)]
		[RegularExpression("[0-9]")]
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

		[Required]
		[MaxLength(20)]
		public string ApplianceModel { get; set; }

		[Required]
		[MaxLength(30)]
		public string ApplianceSerialNumber { get; set; }

		[MaxLength(30)]
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
	}
}