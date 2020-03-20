using System;
using System.Text;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using ERPForServiceActivity.CommonModels.BindingModels.Speedy.ShipmentResponse;

namespace ERPForServiceActivity.CommonModels.ViewModels.Speedy {
	public class SpeedyShipmentViewModel {
		[JsonPropertyName("id")]
		public string Id { get; set; }

		[JsonPropertyName("parcels")]
		public List<SpeedyCreatedShipmentParcel> Parcels { get; set; }

		[JsonPropertyName("price")]
		public SpeedyShipmentPrice Price { get; set; }

		[JsonPropertyName("pickupDate")]
		public DateTime PickupDate { get; set; }

		[JsonPropertyName("deliveryDeadline")]
		public DateTime DeliveryDeadline { get; set; }

		[JsonPropertyName("error")]
		public SpeedyError Error { get; set; }
	}
}
