using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ERPForServiceActivity.CommonModels.BindingModels.Speedy.AdditionalServices.ReturnServices {
	public class BaseSpeedyClass {
		[JsonPropertyName("enabled")]
		public bool Enabled { get; set; }

		[JsonPropertyName("returnToClientId")]
		public long ReturnToClientId { get; set; }

		[JsonPropertyName("returnToOfficeId")]
		public int ReturnToOfficeId { get; set; }

		[JsonPropertyName("thirdPartyPayer")]
		public bool ThirdPartyPayer { get; set; }
	}
}
