using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ERPForServiceActivity.CommonModels.ViewModels.Speedy;
using ERPForServiceActivity.CommonModels.BindingModels.Speedy;

namespace ERPForServiceActivity.Services.Interfaces {
	public interface ISpeedyService {
		public string
			CreateConsignment(
			AddSpeedyShipmentBindingModel model, int id);
	}
}
