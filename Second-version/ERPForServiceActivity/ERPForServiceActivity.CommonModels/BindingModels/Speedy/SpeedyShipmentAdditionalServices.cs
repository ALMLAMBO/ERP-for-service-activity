using System;
using System.Text;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using ERPForServiceActivity.CommonModels.BindingModels.Speedy.AdditionalServices;

namespace ERPForServiceActivity.CommonModels.BindingModels.Speedy {
	public class SpeedyShipmentAdditionalServices {
		[JsonPropertyName("cod")]
		public SpeedyShipmentCODAdditionalService Cod { get; set; }

		[JsonPropertyName("obpd")]
		public SpeedyShipmentOBPD Obpd { get; set; }

		[JsonPropertyName("declaredValue")]
		public SpeedyShipmentDeclaredValueAdditionalService DeclaredValue { get; set; }

		[JsonPropertyName("fixedTimeDelivery")]
		public int FixedTimeDelivery { get; set; }

		[JsonPropertyName("returns")]
		public SpeedyShipmentAdditionalServices Returns { get; set; }

		[JsonPropertyName("specialDeliveryId")]
		public int SpecialDeliveryId { get; set; }

		[JsonPropertyName("deliveryToFloor")]
		public int DeliveryToFloor { get; set; }
	}
}
