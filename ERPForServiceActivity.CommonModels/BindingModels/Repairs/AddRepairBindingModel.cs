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
		public string CustomerName { get; set; }

		[Required]
		public string CustomerAddress { get; set; }
		
		[Required]
		public string CustomerPhoneNumber { get; set; }

		[Required]
		public string DefectByCustomer { get; set; }

		[Required]
		public bool GoingToAddress { get; set; }

		[Required]
		public bool InWarranty { get; set; }

		[Required]
		public string ApplianceBrand { get; set; }

		[Required]
		public string ApplianceType { get; set; }

		[Required]
		public string ApplianceModel { get; set; }

		[Required]
		public string ApplianceSerialNumber { get; set; }

		[Required]
		public string ApplianceProductCodeOrImei { get; set; }

		[Required]
		public string ApplianceEquipment { get; set; }

		[Required]
		public string BoughtFrom { get; set; }

		[Required]
		public string WarrantyCardNumber { get; set; }

		[Required]
		public int WarrantyPeriod { get; set; }

		[Required]
		[DataType(DataType.Date)]
		public DateTime BoughtAt { get; set; }

		public string AdditionalInformation { get; set; }
	}
}