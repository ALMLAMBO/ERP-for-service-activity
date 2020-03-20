using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ERPForServiceActivity.CommonModels.BindingModels.Speedy;
using System.Text.Json.Serialization;

namespace ERPForServiceActivity.CommonModels.BindingModels.Speedy {
	public class AddSpeedyShipmentBindingModel {
		[Required]
		[JsonPropertyName("userName")]
		public string Username { get; set; }

		[Required]
		[JsonPropertyName("password")]
		public string Password { get; set; }

		[JsonPropertyName("language")]
		public string Language { get; set; } = "BG";

		[JsonPropertyName("clientSystemId")]
		public long SystemClientId { get; set; }

		[JsonPropertyName("sender")]
		public SpeedyShipmentSender Sender { get; set; }

		[Required]
		[JsonPropertyName("recipient")]
		public SpeedyShipmentRecipient Recipient { get; set; }

		[Required]
		[JsonPropertyName("service")]
		public SpeedyShipmentService Service { get; set; }

		[Required]
		[JsonPropertyName("content")]
		public SpeedyShipmentContent Content { get; set; }

		[Required]
		[JsonPropertyName("payment")]
		public SpeedyShipmentPayment Payment { get; set; }

		[MaxLength(200)]
		[JsonPropertyName("shipmentNote")]
		public string ShipmentNote { get; set; }

		[JsonPropertyName("ref1")]
		public string Ref1 { get; set; }

		[JsonPropertyName("ref2")]
		public string Ref2 { get; set; }

		[JsonPropertyName("consolidationRef")]
		public string ConsolidationRef { get; set; }

		[JsonPropertyName("requireUnsuccessfulDeliveryStickerImage")]
		public bool RequireUnsuccessfulDeliveryStickerImage { get; set; }
	}
}
