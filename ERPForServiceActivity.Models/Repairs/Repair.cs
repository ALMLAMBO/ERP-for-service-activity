using BlazorInputFile;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERPForServiceActivity.Models.Repairs {
	public class Repair {
		[Required]
		public int RepairId { get; set; }

		public string CustomerName { get; set; }

		public string CustomerAddress { get; set; }

		public bool GoingToAddress { get; set; }

		public string CustomerPhoneNumber { get; set; }

		public bool InWarranty { get; set; }

		public string ApplicanceBrand { get; set; }

		public string ApplianceType { get; set; }

		public string ApplianceModel { get; set; }

		public string ApplianceSerialNumber { get; set; }

		public string ApplianceProductCodeOrImei { get; set; }

		public long WarrantyCardNumber { get; set; }

		[DataType(DataType.Date)]
		public DateTime BoughtAt { get; set; }

		public string Defect { get; set; }

		public string AdditionalInformation { get; set; }

		public IFileListEntry AppliancePhotoInfo { get; set; }

		public IFileListEntry [] OtherPhotos { get; set; }
	}
}
