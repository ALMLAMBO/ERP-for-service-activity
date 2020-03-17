using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ERPForServiceActivity.CommonModels.BindingModels.Speedy.AdditionalServices.ReturnServices {
	public class SpeedyShipmentRODAdditionalService : 
		BaseSpeedyClass {

		[JsonPropertyName("comment")]
		public string Comment { get; set; }
	}
}
