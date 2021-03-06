﻿using System;
using System.Text;
using System.Collections.Generic;
using Google.Cloud.Firestore;

namespace ERPForServiceActivity.Models.Repairs {
	[FirestoreData]
	public class RepairLog {
		[FirestoreProperty]
		public DateTime TimeOfEvent { get; set; }

		[FirestoreProperty]
		public string TypeOfEvent { get; set; }

		[FirestoreProperty]
		public int RepairId { get; set; }

		[FirestoreProperty]
		public string Status { get; set; }

		[FirestoreProperty]
		public string Description { get; set; }
	}
}
