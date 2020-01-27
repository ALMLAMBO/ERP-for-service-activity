using ERPForServiceActivity.CommonModels.BindingModels.Repairs;

namespace ERPForServiceActivity.Services.Interfaces {
	public interface IRepairInterface {
		public void UploadRepair(string ServiceName, AddRepairBindingModel repair);
	}
}
