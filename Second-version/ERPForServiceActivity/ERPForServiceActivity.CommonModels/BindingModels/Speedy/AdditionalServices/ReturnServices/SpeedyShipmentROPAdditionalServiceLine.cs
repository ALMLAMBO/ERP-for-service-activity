using System.Text.Json.Serialization;

namespace ERPForServiceActivity.CommonModels.BindingModels.Speedy.AdditionalServices.ReturnServices {
	public class SpeedyShipmentROPAdditionalServiceLine {
		[JsonPropertyName("serviceId")]
		public int ServiceId { get; set; }

		[JsonPropertyName("parcelsCount")]
		public int ParcelsCount { get; set; }
	}
}