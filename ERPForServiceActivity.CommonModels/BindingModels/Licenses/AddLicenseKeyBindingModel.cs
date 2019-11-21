using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERPForServiceActivity.CommonModels.BindingModels.Licenses {
	[FirestoreData]
	public class AddLicenseKeyBindingModel {
		[FirestoreProperty]
		public string UserId { get; set; }

		[FirestoreProperty]
		public string LicenseKey { get; set; }
	}
}
