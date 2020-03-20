using System;
using System.Collections.Generic;
using System.Text;

namespace ERPForServiceActivity.CommonModels.ViewModels.Checkup {
	public class TechniciаnCheckupViewModel: BaseCheckup {
		public string Name { get; set; }

		public string Brand { get; set; }

		public string Model { get; set; }

		public double Labor { get; set; }
	}
}
