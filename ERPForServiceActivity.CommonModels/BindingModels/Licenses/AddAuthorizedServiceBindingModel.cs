using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Google.Cloud.Firestore;

namespace ERPForServiceActivity.CommonModels.BindingModels.Licenses {
	[FirestoreData]
	public class AddAuthorizedServiceBindingModel {
		public string Id { get; set; }
		
		[FirestoreProperty]
		[Required]
		[DataType(DataType.Text)]
		public string AuthorizedService { get; set; }

		[FirestoreProperty]
		public string UserId { get; set; }

		[FirestoreProperty]
		[Required]
		public string LicenseKey { get; set; }
	}
}
