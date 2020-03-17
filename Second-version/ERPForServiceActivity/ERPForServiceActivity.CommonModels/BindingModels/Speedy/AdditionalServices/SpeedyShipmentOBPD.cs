using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ERPForServiceActivity.CommonModels.BindingModels.Speedy.AdditionalServices {
	public class SpeedyShipmentOBPD {
		[JsonPropertyName("option")]
		public string Option { get; set; }

		[JsonPropertyName("returnShipmentServiceId")]
		public int ReturnShipmentServiceId { get; set; }

		[JsonPropertyName("returnShipmentPayer")]
		public string ReturnShipmentPayer { get; set; }
	}
}
