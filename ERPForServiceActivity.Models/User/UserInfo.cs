using System.ComponentModel.DataAnnotations;
using ERPForServiceActivity.Common;

namespace ERPForServiceActivity.Models.User {
	public class UserInfo {
		[Required]
		[DataType(DataType.EmailAddress, ErrorMessage = 
			CommonConstants.EnteredInvalidEmailAddress)]

		public string Email { get; set; }

		[Required]
		public string Username { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required]
		public string Role { get; set; }
	}
}