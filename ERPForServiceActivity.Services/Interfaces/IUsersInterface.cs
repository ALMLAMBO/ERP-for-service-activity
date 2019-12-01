using System.Threading.Tasks;
using ERPForServiceActivity.Models.User;
using FirebaseAdmin.Auth;

namespace ERPForServiceActivity.Services.Interfaces {
	public interface IUsersInterface {
		public void AddUser(string role, UserInfo userToAdd);

		public Task<UserRecord> GetUserData(string uid);

		public void DeleteUser(string uid);
	}
}