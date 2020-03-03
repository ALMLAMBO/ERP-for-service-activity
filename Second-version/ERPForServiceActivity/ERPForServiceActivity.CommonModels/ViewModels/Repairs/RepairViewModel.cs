using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ERPForServiceActivity.Common;

namespace ERPForServiceActivity.CommonModels.ViewModels.Repairs {
	public class RepairViewModel {
		public int RepairId { get; set; }

		public string RepairStatus { get; set; }

		public List<string> Statuses { get; set; } = CommonConstants.Statuses;

		public List<string> Parts { get; set; } = new List<string>();

		public DateTime CreatedAt { get; set; }
		
		public string CustomerName { get; set; }
		
		public string CustomerAddress { get; set; }
		
		public string CustomerPhoneNumber { get; set; }
		
		public string DefectByCustomer { get; set; }
		
		public bool GoingToAddress { get; set; }
		
		public bool InWarranty { get; set; }
		
		public string ApplianceBrand { get; set; }
		
		public string ApplianceType { get; set; }
		
		public string ApplianceModel { get; set; }
		
		public string ApplianceSerialNumber { get; set; }
		
		public string ApplianceProductCodeOrImei { get; set; }
		
		public string ApplianceEquipment { get; set; }
		
		public string BoughtFrom { get; set; }
		
		public string WarrantyCardNumber { get; set; }
		
		public int WarrantyPeriod { get; set; }

		public DateTime BoughtAt { get; set; }

		public string AdditionalInformation { get; set; }

		public string Notes { get; set; }
	}
}
