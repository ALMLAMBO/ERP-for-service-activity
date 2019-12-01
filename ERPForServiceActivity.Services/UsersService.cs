using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FirebaseAdmin.Auth;
using ERPForServiceActivity.Services.Interfaces;
using ERPForServiceActivity.Models.User;
using System.Security.Claims;
using ERPForServiceActivity.Security;

namespace ERPForServiceActivity.Services {
	public class UsersService : IUsersInterface {
		public async void AddUser(string role, UserInfo userToAdd) {
			Dictionary<string, object> claims = new Dictionary<string, object> {
				{ ClaimTypes.Role, userToAdd.Role }
			};

			UserRecordArgs newUser = new UserRecordArgs() {
				Email = userToAdd.Email,
				EmailVerified = false,
				Password = CommonSecurityConstants.FirstPassword,
				Disabled = false
			};

			UserRecord record = await FirebaseAuth
				.DefaultInstance.CreateUserAsync(newUser);

			await FirebaseAuth.DefaultInstance
				.SetCustomUserClaimsAsync(record.Uid, claims);
		}

		public async void DeleteUser(string uid) {
			await FirebaseAuth.DefaultInstance.DeleteUserAsync(uid);
		}

		public async Task<UserRecord> GetUserData(string uid) {
			return await FirebaseAuth.DefaultInstance.GetUserAsync(uid);
		}
	}
}