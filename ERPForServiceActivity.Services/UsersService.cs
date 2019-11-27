using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FirebaseAdmin.Auth;
using ERPForServiceActivity.Services.Interfaces;
using ERPForServiceActivity.Models.User;

namespace ERPForServiceActivity.Services {
	public class UsersService : IUsersInterface {
		public async void AddUser(string role, UserInfo userToAdd) {
			//TODO IT
			throw new NotImplementedException();
		}

		public async void DeleteUser(string uid) {
			await FirebaseAuth.DefaultInstance.DeleteUserAsync(uid);
		}

		public async Task<UserRecord> GetUserData(string uid) {
			return await FirebaseAuth.DefaultInstance.GetUserAsync(uid);
		}

		public async void UpdateUser(string uid, UserRecordArgs updatedUser) {
			//TODO IT
			throw new NotImplementedException();
		}
	}
}