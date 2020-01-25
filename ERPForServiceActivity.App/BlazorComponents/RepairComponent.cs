using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Blazor.Components;
using ERPForServiceActivity.CommonModels.ViewModels.Repairs;

namespace ERPForServiceActivity.App.BlazorComponents {
	public class RepairComponent : LayoutComponentBase {
		public static List<RepairViewModel> repairs = null;

		public async Task<List<RepairViewModel>> GetRepairs(string serviceName) {
			HttpClient client = new HttpClient();

			await client
				.GetAsync($"https://localhost:44355/api/repairs/get-repairs/{serviceName}")
				.ContinueWith((taskWithResponse) => {
					var response = taskWithResponse.Result;
					string jsonString = response.Content
						.ReadAsStringAsync().Result;

					repairs = JsonConvert
						.DeserializeObject<
							List<RepairViewModel>>(jsonString);
				});

			return repairs;
		}
	}
}
