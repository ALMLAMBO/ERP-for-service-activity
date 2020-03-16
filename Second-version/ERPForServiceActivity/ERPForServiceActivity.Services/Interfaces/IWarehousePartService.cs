using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using ERPForServiceActivity.CommonModels.ViewModels.Warehouse;
using ERPForServiceActivity.CommonModels.BindingModels.WarehouseParts;

namespace ERPForServiceActivity.Services.Interfaces {
	public interface IWarehousePartService {
		public void AddWarehousePart(AddWarehousePartBindingModel model,
			string serviceName);

		public Task<List<WarehousePartViewModel>> GetAllParts(string serviceName);

		public List<WarehousePartViewModel> SearchItems(
			string data, List<WarehousePartViewModel> parts);
	}
}
