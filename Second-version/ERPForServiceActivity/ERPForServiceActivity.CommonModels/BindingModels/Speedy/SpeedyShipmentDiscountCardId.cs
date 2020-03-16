using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ERPForServiceActivity.CommonModels.BindingModels.Speedy {
	public class SpeedyShipmentDiscountCardId {
		[Required]
		[JsonPropertyName("contractId")]
		public long ContractId { get; set; }

		[Required]
		[JsonPropertyName("cartId")]
		public long CartId { get; set; }
	}
}
