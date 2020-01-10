using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Claims;
using FirebaseAdmin.Auth;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using ERPForServiceActivity.Services.Interfaces;
using ERPForServiceActivity.Security;
using ERPForServiceActivity.CommonModels.BindingModels.Users;
using ERPForServiceActivity.Models.User;

namespace ERPForServiceActivity.Services {
	public class UsersService : IUsersInterface {
		public UsersService() {
			FirebaseApp.Create(new AppOptions() {
				Credential = GoogleCredential.FromFile(
					CommonSecurityConstants.PathToFirebaseAdmin)
			});
		}

		public async void AddUser(AddUserBindingModel userToAdd) {
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

		public async Task<UserRecord> GetUserData(string uid) {
			return await FirebaseAuth.DefaultInstance.GetUserAsync(uid);
		}

		public async void UpdateUser(UserInfo user, EditUserBindingModel editUser) {
			if(editUser != null) {
				UserRecord userToUpdate = await FirebaseAuth.DefaultInstance
					.GetUserByEmailAsync(user.Email);

				UserRecordArgs newUserData = new UserRecordArgs() {
					DisplayName = editUser.Username,
					Password = editUser.Password
				};

				await FirebaseAuth.DefaultInstance.UpdateUserAsync(newUserData);
			}
		}

		public async void DeleteUser(string uid) {
			await FirebaseAuth.DefaultInstance.DeleteUserAsync(uid);
		}

		public async Task<bool> LogIn(UserInfo user) {
			UserRecord userResponse = await FirebaseAuth
				.DefaultInstance.GetUserByEmailAsync(user.Email);

			if(userResponse == null) {
				return false;
			}

			return true;
		}

		public void LogOut() {
			
		}
	}
}