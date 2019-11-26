using System.ComponentModel.DataAnnotations;
using Google.Cloud.Firestore;
using ERPForServiceActivity.Common;
using ERPForServiceActivity.Security;

namespace ERPForServiceActivity.CommonModels.BindingModels.Licenses {
	public class AddAuthorizedServiceBindingModel {
		public string Id { get; set; }
		
		[Required]
		[DataType(DataType.Text)]
		[MinLength(CommonConstants.MinLengthServiceName, 
			ErrorMessage = CommonConstants.ErrorMessageWrongLength)]

		public string AuthorizedService { get; set; }

		[Required]
		public string UserId { get; set; }

		[Required]
		[StringLength(CommonSecurityConstants.LicenseLength, 
			ErrorMessage = CommonConstants.ErrorMessageIncorrectLicense)]

		public string LicenseKey { get; set; }
	}
}
