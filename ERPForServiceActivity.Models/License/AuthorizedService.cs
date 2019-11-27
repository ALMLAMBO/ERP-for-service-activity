using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ERPForServiceActivity.Common;
using ERPForServiceActivity.Security;
using Google.Cloud.Firestore;

namespace ERPForServiceActivity.Models.License {
	[FirestoreData]
	public class AuthorizedService {
		public AuthorizedService() {

		}
		
		public string Id { get; set; }

		[Required]
		[FirestoreProperty]
		[DataType(DataType.Text)]
		[MinLength(CommonConstants.MinLengthServiceName,
			ErrorMessage = CommonConstants.ErrorMessageWrongLength)]

		public string AuthorizedServiceName { get; set; }

		[Required]
		[FirestoreProperty]
		public string UserId { get; set; }

		[Required]
		[FirestoreProperty]
		[StringLength(CommonSecurityConstants.LicenseLength,
			ErrorMessage = CommonConstants.ErrorMessageIncorrectLicense)]

		public string LicenseKey { get; set; }
	}
}