using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ERPForServiceActivity.CommonModels.BindingModels.Speedy.ShipmentResponse {
	public class SpeedyShipmentPrice {
		[JsonPropertyName("amount")]
		public double Amount { get; set; }

		[JsonPropertyName("vat")]
		public double Vat { get; set; }

		[JsonPropertyName("total")]
		public double Total { get; set; }

		[JsonPropertyName("currency")]
		public string Currency { get; set; }

		[JsonPropertyName("details")]
		public Dictionary<string, SpeedyShipmentPriceAmount> Details { get; set; }

		[JsonPropertyName("amountLocal")]
		public double AmountLocal { get; set; }

		[JsonPropertyName("vatLocal")]
		public double VatLocal { get; set; }

		[JsonPropertyName("totalLocal")]
		public double TotalLocal { get; set; }

		[JsonPropertyName("currencyLocal")]
		public string CurrencyLocal { get; set; }

		[JsonPropertyName("detailsLocal")]
		public Dictionary<string, SpeedyShipmentPriceAmount> DetailsLocal { get; set; }

		[JsonPropertyName("currencyExchangeRateUnit")]
		public int CurrencyExchangeRateUnit { get; set; }

		[JsonPropertyName("currencyExchangeRate")]
		public double CurrencyExchangeRate { get; set; }
	}
}
