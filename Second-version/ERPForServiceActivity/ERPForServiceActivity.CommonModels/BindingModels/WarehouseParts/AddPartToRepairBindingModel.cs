using System;
using System.Text;
using System.Collections.Generic;
using MatBlazor;

namespace ERPForServiceActivity.CommonModels.BindingModels.WarehouseParts {
	public class AddPartToRepairBindingModel {
		public int RepairId { get; set; }

		public string PartNumber { get; set; }

		public string Description { get; set; }

		public IMatFileUploadEntry file { get; set; }
	}
}
