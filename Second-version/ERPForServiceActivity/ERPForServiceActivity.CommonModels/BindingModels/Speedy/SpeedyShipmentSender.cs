using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ERPForServiceActivity.CommonModels.BindingModels.Speedy {
	public class SpeedyShipmentSender {
		[JsonPropertyName("clientId")]
		public long ClientId { get; set; }

		[JsonPropertyName("phone1")]
		public SpeedyShipmentPhoneNumber Phone1 { get; set; }

		[JsonPropertyName("phone2")]
		public SpeedyShipmentPhoneNumber Phone2 { get; set; }

		[JsonPropertyName("phone3")]
		public SpeedyShipmentPhoneNumber Phone3 { get; set; }

		[JsonPropertyName("clientName")]
		public string ClientName { get; set; }

		[JsonPropertyName("email")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[JsonPropertyName("contactName")]
		public string ContactName { get; set; }

		[JsonPropertyName("privatePerson")]
		public bool PrivatePerson { get; set; }

		[JsonPropertyName("address")]
		public SpeedyShipmentAddress Address { get; set; }

		[JsonPropertyName("dropoffOfficeId")]
		public int DropoffOfficeId { get; set; }
	}
}
