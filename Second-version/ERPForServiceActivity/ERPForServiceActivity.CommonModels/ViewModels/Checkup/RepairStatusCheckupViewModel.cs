using System;
using System.Collections.Generic;
using System.Text;

namespace ERPForServiceActivity.CommonModels.ViewModels.Checkup {
	public class RepairStatusCheckupViewModel : BaseCheckup {
		public int RepairId { get; set; }

		public string Status { get; set; }

		public bool GoingToAddress { get; set; }

		public string UnitModel { get; set; }

		public string CustomerAddress { get; set; }

		public string CustomerPhoneNumber { get; set; }
	}
}
