using System.Threading.Tasks;
using Google.Cloud.Firestore;
using ERPForServiceActivity.Models.Repairs;
using ERPForServiceActivity.Services.Interfaces.Repairs;
using ERPForServiceActivity.CommonModels.BindingModels.Repairs;

namespace ERPForServiceActivity.Services.Implementations.Repairs {
	public class RepairService : BaseService, IRepairService {
		public async Task<bool> UploadRepair(
			AddRepairBindingModel model) {

			Repair repair = Mapper.Map<Repair>(model);

			CollectionReference collection = Database
				.Collection("service-repairs");

			bool result = await Database
				.RunTransactionAsync(async t => {
					Task<DocumentReference> resultFromAdding =
						collection.AddAsync(repair);

					await resultFromAdding;

					return resultFromAdding.IsCompletedSuccessfully;
				});

			return result;
		}
	}
}
