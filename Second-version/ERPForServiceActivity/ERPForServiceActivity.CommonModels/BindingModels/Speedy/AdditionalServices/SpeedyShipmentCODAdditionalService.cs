using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace ERPForServiceActivity.CommonModels.BindingModels.Speedy.AdditionalServices {
	public class SpeedyShipmentCODAdditionalService {
		[Required]
		[JsonPropertyName("amount")]
		public double Amount { get; set; }

		[JsonPropertyName("currencyCode")]
		public string CurrencyCode { get; set; }

		[JsonPropertyName("processingType")]
		public string ProcessingType { get; set; } = "CASH";

		[JsonPropertyName("payoutToThirdParty")]
		public bool PayoutToThirdParty { get; set; }

		[JsonPropertyName("payoutToLoggedClient")]
		public bool PayoutToLoggedClient { get; set; }

		[JsonPropertyName("includeShippingPrice")]
		public bool IncludeShippingPrice { get; set; }
	}
}
