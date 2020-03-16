using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace ERPForServiceActivity.CommonModels.BindingModels.Speedy {
	public class SpeedyShipmentContent {
		[Required]
		[JsonPropertyName("parcelsCount")]
		public int ParcelsCount { get; set; }

		[Required]
		[JsonPropertyName("totalWeight")]
		public double TotalWeight { get; set; }

		[Required]
		[JsonPropertyName("contents")]
		public string Contents { get; set; }

		[Required]
		[JsonPropertyName("package")]
		public string Package { get; set; }

		[JsonPropertyName("documents")]
		public bool Documents { get; set; }

		[JsonPropertyName("palletized")]
		public bool Palletized { get; set; }

		[JsonPropertyName("parcels")]
		public SpeedyShipmentParcel[] Parcels { get; set; }

		[JsonPropertyName("pendingParcels")]
		public bool PendingParcels { get; set; }
	}
}
