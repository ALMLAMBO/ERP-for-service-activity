using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ERPForServiceActivity.Common;
using ERPForServiceActivity.Security;
using Google.Cloud.Firestore;

namespace ERPForServiceActivity.Models.License {
	[FirestoreData]
	public class LicenseKey {
		public string Id { get; set; }

		[Required]
		[FirestoreProperty]
		public string UserId { get; set; }

		[FirestoreProperty]
		[StringLength(CommonSecurityConstants.LicenseLength,
			ErrorMessage = CommonConstants.ErrorMessageIncorrectLicense)]

		public string LicenseKeyValue { get; set; }
	}
}