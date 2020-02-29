using System;
using System.Text;
using System.Collections.Generic;
using Google.Cloud.Firestore;

namespace ERPForServiceActivity.CommonModels.BindingModels.WarehouseParts {
	[FirestoreData]
	public class RequestPartBindingModel {
		[FirestoreProperty]
		public int RepairId { get; set; }

		[FirestoreProperty]
		public Dictionary<string, int> PartsForRepair { get; set; }
	}
}
