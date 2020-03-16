using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERPForServiceActivity.CommonModels.BindingModels.Repairs {
	public class ResultFromOCRBindingModel {
		[Required]
		public string ApplianceBrand { get; set; }

		[Required]
		public string ApplianceType { get; set; }

		[Required]
		public string ApplianceModel { get; set; }

		[Required]
		public string ApplianceSerialNumber { get; set; }
	}
}
