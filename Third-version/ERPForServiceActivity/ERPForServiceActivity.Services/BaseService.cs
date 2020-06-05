using AutoMapper;
using Google.Cloud.Firestore;
using ERPForServiceActivity.Data;
using ERPForServiceActivity.Models.Repairs;
using ERPForServiceActivity.CommonModels.BindingModels.Repairs;

namespace ERPForServiceActivity.Services {
	public class BaseService {
		private DatabaseConnection connection =
			new DatabaseConnection();

		private MapperConfiguration configuration =
			new MapperConfiguration(config => {
				config.CreateMap<AddRepairBindingModel, Repair>();
			});

		public FirestoreDb Database {
			get {
				return connection.GetFirestoreDb().Result;
			}
		}

		public Mapper Mapper {
			get {
				return new Mapper(configuration);
			}
		}

	}
}
