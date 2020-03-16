using System.Drawing;
using System.Threading.Tasks;
using System.Collections.Generic;
using MatBlazor;
using ERPForServiceActivity.Models.Repairs;
using ERPForServiceActivity.CommonModels.ViewModels.Repairs;
using ERPForServiceActivity.CommonModels.ViewModels.Warehouse;
using ERPForServiceActivity.CommonModels.BindingModels.Repairs;

namespace ERPForServiceActivity.Services.Interfaces {
	public interface IRepairService {
		public Task<List<RepairViewModel>> GetAllRepairs(string serviceName);
		
		public void UploadRepair(
			string ServiceName, AddRepairBindingModel repair);

		public void UploadLog(RepairLog log);

		public Task<int> GetLastId(string serviceName);
	
		public Task<ResultFromOCRBindingModel> GetData(
			/*ResultFromOCRBindingModel model, MatFileUploadEntry file*/);

		public void UpdateStatus(string status, int id);

		public void UpdateRepair(RepairViewModel model);

		public void AddRequestedPartToRepair(
			string partNumber, int id);

		public void AddPartToRepair(string partNumber, int id);

		public void SendPartToRepair(int id, string partNumber, int qnt);

		public Dictionary<string, int> GetPartsForRepair(int id);

		public Task<StatusResult> GetRepairStatus(string name, string reclaim);
	}
}
