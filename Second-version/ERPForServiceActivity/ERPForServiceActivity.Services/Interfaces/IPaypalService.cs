using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using PayPalHttp;

namespace ERPForServiceActivity.Services.Interfaces {
	public interface IPaypalService {
		public Task<HttpResponse> GetResponse(double value);

		public Task<HttpResponse> CompletePayment(HttpResponse response);
	}
}
