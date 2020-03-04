using System;
using System.Collections.Generic;
using System.Text;

namespace ERPForServiceActivity.CommonModels.ViewModels.Checkup {
	public class BaseCheckup {
		public string ServiceName { get; set; }

		public DateTime BeginDate { get; set; } = DateTime.UtcNow;
		
		public DateTime EndDate { get; set; } = DateTime.UtcNow; 
	}
}
