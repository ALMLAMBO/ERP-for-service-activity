using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ERPForServiceActivity.CommonModels.BindingModels.Speedy.ShipmentResponse {
	public class SpeedyError {
		[JsonPropertyName("context")]
		public string Context { get; set; }

		[JsonPropertyName("message")]
		public string Message { get; set; }
	}
}
