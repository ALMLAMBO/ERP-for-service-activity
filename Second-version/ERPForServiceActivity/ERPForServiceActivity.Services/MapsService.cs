using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Google.Maps;
using Google.Maps.Geocoding;
using ERPForServiceActivity.Security;
using ERPForServiceActivity.Services.Interfaces;
using ERPForServiceActivity.CommonModels.BindingModels.Maps;

namespace ERPForServiceActivity.Services {
	public class MapsService : IMapsService {
		public async Task<MapsCoordinatesBindingModel> 
			GetCoordinates(string address) {

			MapsCoordinatesBindingModel result = 
				new MapsCoordinatesBindingModel();

			GoogleSigned.AssignAllServices(
				new GoogleSigned(CommonSecurityConstants
					.GoogleMapsApiKey));

			GeocodingRequest request = new GeocodingRequest();
			request.Address = new Location(address);

			GeocodeResponse response = await Task.Run(() => {
				return new GeocodingService()
					.GetResponseAsync(request).Result;
			});

			if (response.Status == ServiceResponseStatus.Ok &&
				response.Results.Count() > 0) {

				Result placeResult = response
					.Results.FirstOrDefault();

				result.Lat = placeResult.Geometry
					.Location.Latitude;

				result.Lng = placeResult.Geometry
					.Location.Longitude;
			}

			return result;
		}
	}
}
