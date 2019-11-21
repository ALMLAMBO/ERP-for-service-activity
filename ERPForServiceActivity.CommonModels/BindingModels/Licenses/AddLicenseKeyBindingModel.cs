using System.ComponentModel.DataAnnotations;
using Google.Cloud.Firestore;
using ERPForServiceActivity.Common;
using ERPForServiceActivity.Security;

namespace ERPForServiceActivity.CommonModels.BindingModels.Licenses {
	[FirestoreData]
	public class AddLicenseKeyBindingModel {
		[Required]
		[FirestoreProperty]
		public string UserId { get; set; }

		[FirestoreProperty]
		[StringLength(CommonSecurityConstants.LicenseLength,
			ErrorMessage = CommonConstants.ErrorMessageIncorrectLicense)]

		public string LicenseKey { get; set; }
	}
}
