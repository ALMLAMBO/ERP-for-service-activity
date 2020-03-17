using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ERPForServiceActivity.CommonModels.BindingModels.Speedy.AdditionalServices.ReturnServices {
	public class SpeedyShipmentReturnVoucherAdditionalService {
		[JsonPropertyName("serviceId")]
		public int ServiceId { get; set; }

		[JsonPropertyName("payer")]
		public string Payer { get; set; }
	}
}
