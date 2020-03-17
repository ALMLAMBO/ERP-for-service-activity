using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ERPForServiceActivity.CommonModels.BindingModels.Speedy.AdditionalServices.ReturnServices {
	public class SpeedyShipmentROPAdditionalService {
		[JsonPropertyName("pallets")]
		public List<SpeedyShipmentROPAdditionalServiceLine> Pallets { get; set; }

		[JsonPropertyName("thirdPartyPayer")]
		public bool ThirdPartyPayer { get; set; }
	}
}
