using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ERPForServiceActivity.CommonModels.BindingModels.Speedy {
	public class SpeedyShipmentAddress {
		[JsonPropertyName("countryId")]
		public int CountryId { get; set; }

		[JsonPropertyName("countryName")]
		public string CountryName { get; set; }

		[JsonPropertyName("stateId")]
		public string StateId { get; set; }

		[JsonPropertyName("siteId")]
		public long SiteId { get; set; }

		[JsonPropertyName("siteType")]
		public string SiteType { get; set; }

		[JsonPropertyName("siteName")]
		public string SiteName { get; set; }

		[JsonPropertyName("postCode")]
		public string PostCode { get; set; }

		[JsonPropertyName("streetId")]
		public long StreetId { get; set; }

		[JsonPropertyName("streetName")]
		public string StreetName { get; set; }

		[JsonPropertyName("streetNo")]
		public string StreetNo { get; set; }

		[JsonPropertyName("complexId")]
		public long ComplexId { get; set; }

		[JsonPropertyName("complexType")]
		public string ComplexType { get; set; }

		[JsonPropertyName("complexName")]
		public string ComplexName { get; set; }

		[JsonPropertyName("blockNo")]
		public string BlockNo { get; set; }

		[JsonPropertyName("entranceNo")]
		public string EntranceNo { get; set; }

		[JsonPropertyName("floorNo")]
		public string FloorNo { get; set; }

		[JsonPropertyName("apartmentNo")]
		public string ApartmentNo { get; set; }

		[JsonPropertyName("poilD")]
		public long PoilD { get; set; }

		[JsonPropertyName("streetType")]
		public string StreetType { get; set; }

		[JsonPropertyName("addressNote")]
		public string AddressNote { get; set; }

		[JsonPropertyName("addressLine1")]
		public string AddressLine1 { get; set; }

		[JsonPropertyName("addressLine2")]
		public string AddressLine2 { get; set; }

		[JsonPropertyName("x")]
		public double X { get; set; }

		[JsonPropertyName("y")]
		public double Y { get; set; }
	}
}
