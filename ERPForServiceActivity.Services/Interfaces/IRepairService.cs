using System.Drawing;
using System.Threading.Tasks;
using System.Collections.Generic;
using MatBlazor;
using ERPForServiceActivity.CommonModels.ViewModels.Repairs;
using ERPForServiceActivity.CommonModels.BindingModels.Repairs;

namespace ERPForServiceActivity.Services.Interfaces {
	public interface IRepairService {
		public Task<List<RepairViewModel>> GetAllRepairs(string serviceName);
		
		public void UploadRepair(string ServiceName, AddRepairBindingModel repair);

		public void SaveImageToTemp(IMatFileUploadEntry file);

		public Bitmap ConvertToBitmap(IMatFileUploadEntry file);
		
		public void MoveImageToOriginalDirectory(Bitmap bitmap);

		public void SaveMultipleImagesToTemp(IMatFileUploadEntry[] files);

		public void MoveMultipleImagesToOriginalDirectory(Bitmap[] bitmaps);

		public Bitmap[] ConvertMultipleToBitmap(IMatFileUploadEntry[] files);

		public Task<int> GetLastId(string serviceName);

		public ResultFromOCRBindingModel GetData(
			ResultFromOCRBindingModel model, IMatFileUploadEntry file);
	}
}
