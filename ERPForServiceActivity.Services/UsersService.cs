using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Claims;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using ERPForServiceActivity.Services.Interfaces;
using ERPForServiceActivity.Security;
using ERPForServiceActivity.CommonModels.BindingModels.Users;
using FirebaseAdmin;

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

		public async void DeleteUser(string uid) {
			await FirebaseAuth.DefaultInstance.DeleteUserAsync(uid);
		}

		public async Task<UserRecord> GetUserData(string uid) {
			return await FirebaseAuth.DefaultInstance.GetUserAsync(uid);
		}
	}
}