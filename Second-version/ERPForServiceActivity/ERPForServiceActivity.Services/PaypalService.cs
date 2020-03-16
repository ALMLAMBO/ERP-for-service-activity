using System;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using PayPalHttp;
using PayPalCheckoutSdk.Core;
using PayPalCheckoutSdk.Orders;
using PayPalCheckoutSdk.Payments;
using ERPForServiceActivity.Security;
using ERPForServiceActivity.Services.Interfaces;

namespace ERPForServiceActivity.Services {
	public class PaypalService : IPaypalService {
		public async Task<HttpResponse> 
			CompletePayment(HttpResponse response) {
			
			OrdersCaptureRequest request =
				new OrdersCaptureRequest(
					response.Result<Order>().Id);

			request.RequestUri = new Uri(response
				.Result<Order>().Links[3].Href);

			request.RequestBody(new OrderActionRequest());
			request.ContentType = "application/json";
			request.Prefer("return=representation");

			HttpResponse captureResponse = await Client()
				.Execute(request);

			return captureResponse;
		}

		public async Task<HttpResponse> GetResponse(double value) {
			OrderRequest order = new OrderRequest() {
				CheckoutPaymentIntent = "CAPTURE",
				PurchaseUnits = new List<PurchaseUnitRequest>() {
					new PurchaseUnitRequest() {
						AmountWithBreakdown = new AmountWithBreakdown() {
							CurrencyCode = "EUR",
							Value = $"{Math.Round(value / 1.95583, 2)}"
						}
					}
				},
				ApplicationContext = new ApplicationContext() {
					ReturnUrl = "https://localhost:44351/",
					CancelUrl = "https://localhost:44351/"
				}
			};

			OrdersCreateRequest request = new OrdersCreateRequest();
			request.Prefer("return=representation");
			request.ContentType = "application/json";
			request.RequestBody(order);

			HttpResponse response = await Client().Execute(request);

			return response;
		}

		private HttpClient Client() {
			PayPalEnvironment environment =
				new SandboxEnvironment(
					CommonSecurityConstants.PaypalClientId,
					CommonSecurityConstants.PaypalClientSecret);

			PayPalHttpClient client = new PayPalHttpClient(environment);

			return client;
		}
	}
}
