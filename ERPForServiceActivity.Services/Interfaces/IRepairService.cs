using System.Threading.Tasks;
using System.Collections.Generic;
using ERPForServiceActivity.CommonModels.ViewModels.Repairs;
using ERPForServiceActivity.CommonModels.BindingModels.Repairs;

namespace ERPForServiceActivity.Services.Interfaces {
	public interface IRepairService {
		public void UploadRepair(string ServiceName, AddRepairBindingModel repair);

		public Task<List<RepairViewModel>> GetAllRepairs(string serviceName);
	}
}
