using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ERPForServiceActivity.CommonModels.BindingModels.Speedy {
	public class SpeedyShipmentRecipient : SpeedyShipmentSender {
		[JsonPropertyName("objectName")]
		public string ObjectName { get; set; }

		[JsonPropertyName("pickupOfficeId")]
		public int PickupOfficeId { get; set; }
	}
}
