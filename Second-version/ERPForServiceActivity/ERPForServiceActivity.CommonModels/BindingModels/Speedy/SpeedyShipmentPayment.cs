using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace ERPForServiceActivity.CommonModels.BindingModels.Speedy {
	public class SpeedyShipmentPayment {
		[Required]
		[JsonPropertyName("courierServicePayer")]
		public string CourierServicePayer { get; set; } = PaymentOption.SENDER;

		[JsonPropertyName("declaredValuePayer")]
		public string DeclaredValuePayer { get; set; }

		[JsonPropertyName("packagePayer")]
		public string PackagePayer { get; set; }

		[JsonPropertyName("thirdPartyClientId")]
		public long ThirdPartyClientId { get; set; }

		[JsonPropertyName("discountCardId")]
		public SpeedyShipmentDiscountCardId DiscountCardId { get; set; }
	}
}
