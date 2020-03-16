using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ERPForServiceActivity.CommonModels.BindingModels.Speedy {
	public class SpeedyShipmentParcelSize {
		[Required]
		[JsonPropertyName("width")]
		public int Width { get; set; }

		[Required]
		[JsonPropertyName("height")]
		public int Height { get; set; }

		[Required]
		[JsonPropertyName("depth")]
		public int Depth { get; set; }
	}
}
