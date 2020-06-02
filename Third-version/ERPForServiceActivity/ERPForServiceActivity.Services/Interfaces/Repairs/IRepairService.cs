using System.Threading.Tasks;
using ERPForServiceActivity.CommonModels.BindingModels.Repairs;

namespace ERPForServiceActivity.Services.Interfaces.Repairs {
	public interface IRepairService {
		Task<bool> UploadRepair(AddRepairBindingModel model);
	}
}
