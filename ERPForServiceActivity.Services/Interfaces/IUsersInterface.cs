using System.Threading.Tasks;
using FirebaseAdmin.Auth;
using ERPForServiceActivity.CommonModels.BindingModels.Users;
using ERPForServiceActivity.Models.User;

namespace ERPForServiceActivity.Services.Interfaces {
	public interface IUsersInterface {
		public void AddUser(AddUserBindingModel userToAdd);

		public Task<UserRecord> GetUserData(string uid);

		public void UpdateUser(UserInfo user, EditUserBindingModel editUser);

		public void DeleteUser(string uid);

		public Task<bool> LogIn(UserInfo user);

		public void LogOut();
	}
}