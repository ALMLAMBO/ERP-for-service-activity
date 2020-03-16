using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ERPForServiceActivity.CommonModels.BindingModels.Speedy {
	public class SpeedyShipmentParcel {
		[JsonPropertyName("id")]
		public string Id { get; set; }

		[JsonPropertyName("sequenceNumber")]
		public int SequenceNumber { get; set; }

		[JsonPropertyName("PackageUniqueNumber")]
		public long PackageUniqueNumber { get; set; }

		[JsonPropertyName("Size")]
		public SpeedyShipmentParcelSize size { get; set; }

		[Required]
		[JsonPropertyName("weight")]
		public double Weight { get; set; }

		[JsonPropertyName("externalCarrierParcelNumber")]
		public string ExternalCarrierParcelNumber { get; set; }

		[JsonPropertyName("ref1")]
		public string Ref1 { get; set; }

		[JsonPropertyName("ref2")]
		public string Ref2 { get; set; }
	}
}
