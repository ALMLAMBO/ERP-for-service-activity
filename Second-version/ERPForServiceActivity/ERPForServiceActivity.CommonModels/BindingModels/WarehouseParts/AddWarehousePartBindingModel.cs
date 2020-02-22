using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERPForServiceActivity.CommonModels.BindingModels.WarehouseParts {
	public class AddWarehousePartBindingModel {
		[Required]
		public string PartNumber { get; set; }

		[Required]
		public int Availability { get; set; }

		[Required]
		public List<string> Model { get; set; } = new List<string>();

		[Required]
		public string Description { get; set; }

		[Required]
		public string Brand { get; set; }

		public List<string> SubstituteParts { get; set; } = new List<string>();

		[Required]
		public double Price { get; set; }

		[Required]
		public string Invoice { get; set; }

		[Required]
		public DateTime InvoiceDate { get; set; }

		[Required]
		public DateTime ReceivedDate { get; set; }
	}
}
