using System.ComponentModel.DataAnnotations;
using Google.Cloud.Firestore;
using ERPForServiceActivity.Common;
using ERPForServiceActivity.Security;

namespace ERPForServiceActivity.CommonModels.BindingModels.Licenses {
	public class AddLicenseKeyBindingModel {
		[Required]
		public string UserId { get; set; }

		[StringLength(CommonSecurityConstants.LicenseLength,
			ErrorMessage = CommonConstants.ErrorMessageIncorrectLicense)]

		public string LicenseKey { get; set; }
	}
}