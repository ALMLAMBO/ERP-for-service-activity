using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using ERPForServiceActivity.CommonModels.BindingModels.Speedy.AdditionalServices.ReturnServices;

namespace ERPForServiceActivity.CommonModels.BindingModels.Speedy.AdditionalServices {
	public class SpeedyShipmentReturnAdditionalServices {
		[JsonPropertyName("rod")]
		public SpeedyShipmentRODAdditionalService Rod { get; set; }

		[JsonPropertyName("returnReceipt")]
		public SpeedyShipmentReturnReceiptAdditionalService ReturnReceipt { get; set; }

		[JsonPropertyName("swap")]
		public SpeedyShipmentSWAPAdditionalService Swap { get; set; }

		[JsonPropertyName("rop")]
		public SpeedyShipmentROPAdditionalService Rop { get; set; }

		[JsonPropertyName("returnVoucher")]
		public SpeedyShipmentReturnVoucherAdditionalService ReturnVoucher { get; set; }
	}
}
