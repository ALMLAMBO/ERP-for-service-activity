using System.ComponentModel.DataAnnotations;
using ERPForServiceActivity.Common;

namespace ERPForServiceActivity.CommonModels.BindingModels.Users {
	public class AddUserBindingModel {
		[Required]
		[DataType(DataType.EmailAddress, ErrorMessage =
			CommonConstants.EnteredInvalidEmailAddress)]

		public string Email { get; set; }

		[Required]
		public string Username { get; set; }

		[Required]
		public string Role { get; set; }
	}
}
