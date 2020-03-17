using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ERPForServiceActivity.CommonModels.BindingModels.Speedy.AdditionalServices.ReturnServices {
	public class SpeedyShipmentSWAPAdditionalService {
		[JsonPropertyName("serviceId")]
		public int ServiceId { get; set; }

		[JsonPropertyName("parcelsCount")]
		public int ParcelsCount { get; set; }

		[JsonPropertyName("declaredValue")]
		public double DeclaredValue { get; set; }

		[JsonPropertyName("fragile")]
		public bool Fragile { get; set; }

		[JsonPropertyName("returnToClientId")]
		public long ReturnToClientId { get; set; }

		[JsonPropertyName("returnToOfficeId")]
		public int ReturnToOfficeId { get; set; }
	}
}
