using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using ERPForServiceActivity.CommonModels.BindingModels.Maps;

namespace ERPForServiceActivity.Services.Interfaces {
	public interface IMapsService {
		Task<MapsCoordinatesBindingModel> 
			GetCoordinates(string address);
	}
}
