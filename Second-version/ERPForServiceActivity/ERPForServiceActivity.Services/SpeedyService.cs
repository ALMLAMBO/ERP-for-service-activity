using System;
using System.Text;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Encodings;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Google.Cloud.Firestore;
using ERPForServiceActivity.Data;
using ERPForServiceActivity.Models.Speedy;
using ERPForServiceActivity.Services.Interfaces;
using ERPForServiceActivity.CommonModels.ViewModels.Speedy;
using ERPForServiceActivity.CommonModels.BindingModels.Speedy;

namespace ERPForServiceActivity.Services {
	public class SpeedyService : ISpeedyService {
		public string CreateConsignment(
			AddSpeedyShipmentBindingModel model, int id) {

			HttpClient client = new HttpClient();
			JsonSerializerOptions options = new JsonSerializerOptions() {
				IgnoreNullValues = true
			};

			model.Username = "999178";
			model.Password = "1868743943";

			model.Service = new SpeedyShipmentService() {
				ServiceId = 505,
				DeferredDays = 0,
				SaturdayDelivery = false,
				AutoAdjustPickupDate = false
			};

			model.Content = new SpeedyShipmentContent() {
				ParcelsCount = 1,
				TotalWeight = 0.5,
				Contents = "КОЗМЕТИКА",
				Package = "КУТИЯ",
				Documents = false,
				Palletized = false,
				PendingParcels = false
			};

			model.Payment = new SpeedyShipmentPayment() {
				
			};

			model.Recipient = new SpeedyShipmentRecipient() {
				ClientId = 0,
				Phone1 = new SpeedyShipmentPhoneNumber() {
					Number = "00359882710483"
				},
				ClientName = "ИВАН МАРИНОВ",
				PrivatePerson = true,
				Email = "ivan2081@abv.bg",
				Address = new SpeedyShipmentAddress() {
					CountryId = 100,
					SiteType = "гр.",
					SiteName = "СОФИЯ",
					StreetType = "жк.",
					StreetName = "Младост 3",
					BlockNo = "310",
					EntranceNo = "A",
					FloorNo = "11",
					ApartmentNo = "81",
				},
				PickupOfficeId = 0
			};

			client.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue(
					"application/json"));

			HttpRequestMessage message = new HttpRequestMessage(
				HttpMethod.Post, "https://api.speedy.bg/v1/shipment");

			message.Content = new StringContent(
				JsonSerializer.Serialize(model, options),
				Encoding.UTF8,
				"application/json");

			HttpResponseMessage response = client
				.SendAsync(message).Result;

			string json = response.Content
				.ReadAsStringAsync().Result;

			Regex regex = new Regex("[0-9]{11}");
			return regex.Match(json).Value;
		}
	}
}
