using System.Drawing;
using System.Threading.Tasks;
using System.Collections.Generic;
using MatBlazor;
using ERPForServiceActivity.CommonModels.ViewModels.Repairs;
using ERPForServiceActivity.CommonModels.BindingModels.Repairs;

namespace ERPForServiceActivity.Services.Interfaces {
	public interface IRepairService {
		public Task<List<RepairViewModel>> GetAllRepairs(string serviceName);
		
		public void UploadRepair(
			string ServiceName, AddRepairBindingModel repair);

		public Bitmap ConvertToBitmap(IMatFileUploadEntry file);

		public void MoveImageToOriginalDirectory(
			string path, int id);

		public void SaveImageToTemp(
			IMatFileUploadEntry file, string path);

		public Bitmap[] ConvertMultipleToBitmap(
			IMatFileUploadEntry[] files);

		public void MoveMultipleImagesToOriginalDirectory(
			string path, int id);

		public void SaveMultipleImagesToTemp(
			IMatFileUploadEntry[] files, string path);

		public Task<int> GetLastId(string serviceName);
		
		public string GetImagePath(string path, int index);

		public ResultFromOCRBindingModel GetData(
			ResultFromOCRBindingModel model);
	}
}
