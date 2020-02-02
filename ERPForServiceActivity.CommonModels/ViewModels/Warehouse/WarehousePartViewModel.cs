using System;
using System.Text;
using System.Collections.Generic;
using ERPForServiceActivity.Common;

namespace ERPForServiceActivity.CommonModels.ViewModels.Warehouse {
	public class WarehousePartViewModel {

		public string PartNumber { get; set; }
		
		public int Availability { get; set; }
		
		public string Model { get; set; }
		
		public string Description { get; set; }
		
		public string Brand { get; set; }
		
		public List<string> SubstituteParts { get; set; }
		
		public List<string> SubstituteModels { get; set; }

		public double Price { get; set; }
		
		public string Invoice { get; set; }
		
		public DateTime InvoiceDate { get; set; }
		
		public DateTime ReceivedDate { get; set; }
	}
}
