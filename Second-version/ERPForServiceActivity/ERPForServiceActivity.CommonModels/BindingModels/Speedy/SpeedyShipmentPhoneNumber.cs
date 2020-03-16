using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ERPForServiceActivity.CommonModels.BindingModels.Speedy {
	public class SpeedyShipmentPhoneNumber {
		[Required]
		[JsonPropertyName("number")]
		public string Number { get; set; }

		[JsonPropertyName("extension")]
		public string Extension { get; set; }
	}
}
