using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ERPForServiceActivity.CommonModels.BindingModels.Speedy.AdditionalServices {
	public class SpeedyShipmentDeclaredValueAdditionalService {
		[JsonPropertyName("amount")]
		public double Amount { get; set; }

		[JsonPropertyName("fragile")]
		public bool Fragile { get; set; }

		[JsonPropertyName("ignoreIfNotApplicable")]
		public bool IgnoreIfNotApplicable { get; set; }
	}
}
