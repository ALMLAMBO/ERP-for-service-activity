using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ERPForServiceActivity.CommonModels.BindingModels.Speedy {
	public class SpeedyShipmentService {
		[JsonPropertyName("pickupDate")]
		public DateTime PickupDate { get; set; } = DateTime.Now;

		[JsonPropertyName("autoAdjustPickupDate")]
		public bool AutoAdjustPickupDate { get; set; }

		[JsonPropertyName("deferredDays")]
		public int DeferredDays { get; set; }

		[JsonPropertyName("serviceId")]
		public int ServiceId { get; set; }

		[JsonPropertyName("additionalServices")]
		public SpeedyShipmentAdditionalServices AdditionalServices { get; set; }

		[JsonPropertyName("saturdayDelivery")]
		public bool SaturdayDelivery { get; set; }
	}
}
