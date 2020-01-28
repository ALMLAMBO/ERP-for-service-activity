using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERPForServiceActivity.CommonModels.BindingModels.WarehouseParts {
	public class EditWarehousePartBindingModel {
		[Required]
		public int Availability { get; set; }
	}
}
