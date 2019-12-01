using System.Threading.Tasks;
using FirebaseAdmin.Auth;
using ERPForServiceActivity.CommonModels.BindingModels.Users;

namespace ERPForServiceActivity.Services.Interfaces {
	public interface IUsersInterface {
		public void AddUser(AddUserBindingModel userToAdd);

		public Task<UserRecord> GetUserData(string uid);

		public void DeleteUser(string uid);
	}
}