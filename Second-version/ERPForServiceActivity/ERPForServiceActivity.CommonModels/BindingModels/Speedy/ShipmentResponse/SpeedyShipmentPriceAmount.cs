using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ERPForServiceActivity.CommonModels.BindingModels.Speedy.ShipmentResponse {
	public class SpeedyShipmentPriceAmount {
		[JsonPropertyName("amount")]
		public double Amount { get; set; }

		[JsonPropertyName("percent")]
		public double Percent { get; set; }

		[JsonPropertyName("vatPercent")]
		public double VatPercent { get; set; }
	}
}
