using System;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Blazor.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components.Authorization;
using ERPForServiceActivity.Common;
using ERPForServiceActivity.App.Data;
using ERPForServiceActivity.Services;
using ERPForServiceActivity.Services.Interfaces;

namespace ERPForServiceActivity.App {
	public class Startup {
		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services) {
			services.AddRazorPages();
			services.AddAuthorization();
			services.AddAuthentication();
			services.AddServerSideBlazor()
				.AddHubOptions(options => {
					options.MaximumReceiveMessageSize =
						10 * 1024 * 1024;
				});

			services.AddSingleton<IUserService, UserService>();
			services.AddSingleton<IRepairService, RepairService>();
			services.AddSingleton<IWarehousePartService, 
				WarehousePartService>();
			
			services.AddScoped<HttpClient>();

			if (!services.Any(x => x.ServiceType == typeof(HttpClient))) {
				services.AddScoped<HttpClient>(s => {
					var uriHelper = s.GetRequiredService<NavigationManager>();

					return new HttpClient() {
						BaseAddress = new Uri(uriHelper.BaseUri)
					};
				});
			}
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
			if (env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
			} else {
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints => {
				//endpoints.MapControllers();
				endpoints.MapBlazorHub();
				endpoints.MapFallbackToPage("/_Host");
			});
		}
	}
}
