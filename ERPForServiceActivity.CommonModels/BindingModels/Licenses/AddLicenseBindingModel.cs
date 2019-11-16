using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Google.Cloud.Firestore;

namespace ERPForServiceActivity.CommonModels.BindingModels.Licenses {
	[FirestoreData]
	public class AddLicenseBindingModel {
		public string Id { get; set; }
		
		[FirestoreProperty]
		[Required]
		[DataType(DataType.Text)]
		public string ServiceName { get; set; }

		[FirestoreProperty]
		public List<LicenseKeyBindingModel> LicenseKeys { get; set; }
	}
}
