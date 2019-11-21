using System.ComponentModel.DataAnnotations;
using Google.Cloud.Firestore;
using ERPForServiceActivity.Common;
using ERPForServiceActivity.Security;

namespace ERPForServiceActivity.CommonModels.BindingModels.Licenses {
	[FirestoreData]
	public class AddAuthorizedServiceBindingModel {
		public string Id { get; set; }
		
		[Required]
		[FirestoreProperty]
		[DataType(DataType.Text)]
		[MinLength(CommonConstants.MinLengthServiceName, 
			ErrorMessage = CommonConstants.ErrorMessageWrongLength)]

		public string AuthorizedService { get; set; }

		[FirestoreProperty]
		public string UserId { get; set; }

		[Required]
		[FirestoreProperty]
		[StringLength(CommonSecurityConstants.LicenseLength, 
			ErrorMessage = CommonConstants.ErrorMessageIncorrectLicense)]

		public string LicenseKey { get; set; }
	}
}
