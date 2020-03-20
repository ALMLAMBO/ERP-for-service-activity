using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ERPForServiceActivity.CommonModels.BindingModels.Speedy.ShipmentResponse {
	public class SpeedyCreatedShipmentParcel {
		[JsonPropertyName("seqNo")]
		public int SeqNo { get; set; }

		[JsonPropertyName("id")]
		public string Id { get; set; }
	}
}
