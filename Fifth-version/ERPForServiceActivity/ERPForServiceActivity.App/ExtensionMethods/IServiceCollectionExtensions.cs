using System;
using System.Linq;
using System.Net.Http;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using ERPForServiceActivity.Security;
//using ERPForServiceActivity.Services.Interfaces.Repairs;
//using ERPForServiceActivity.Services.Implementations.Repairs;

namespace ERPForServiceActivity.App.ExtensionMethods {
	public static class IServiceCollectionExtensions {
		public static void AddServices(
			this IServiceCollection services) {

			//services.AddSingleton<IRepairService, RepairService>();
		}

		public static void ConfigureAuthentication(
			this IServiceCollection services) {

			services.AddAuthorization();
			services
				.AddAuthentication(options => {
					options.DefaultAuthenticateScheme =
						CookieAuthenticationDefaults.AuthenticationScheme;

					options.DefaultSignInScheme =
						CookieAuthenticationDefaults.AuthenticationScheme;

					options.DefaultSignOutScheme =
						CookieAuthenticationDefaults.AuthenticationScheme;

					options.DefaultChallengeScheme =
						OpenIdConnectDefaults.AuthenticationScheme;
				})
				.AddOpenIdConnect(options => {
					options.ClientId = OktaConstants.OktaClientId;
					options.ClientSecret = OktaConstants.OktaClientSecret;
					options.CallbackPath = "/authorization-code/callback";
					options.Authority = OktaConstants.OktaIssuer;
					options.ResponseType = "code";
					options.SaveTokens = true;
					options.Scope.Add("openid");
					options.Scope.Add("profile");
					options.TokenValidationParameters.ValidateIssuer = false;
					options.TokenValidationParameters.NameClaimType = "name";
				})
				.AddCookie(options => {
					options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
				});
		}

		public static void ConfigureHttpClient(
			this IServiceCollection services) {

			if (!services.Any(x => x.ServiceType == typeof(HttpClient))) {
				services.AddScoped<HttpClient>(s => {
					NavigationManager uriHelper = s
						.GetRequiredService<NavigationManager>();

					return new HttpClient() {
						BaseAddress = new Uri(uriHelper.BaseUri)
					};
				});
			}
		}

		public static void ConfigureMatToast(
			this IServiceCollection services) {

			services.AddMatToaster(config => {
				config.NewestOnTop = true;
				config.ShowCloseButton = true;
				config.ShowProgressBar = true;
				config.PreventDuplicates = true;
				config.MaximumOpacity = 100;
				config.ShowStepDuration = 200;
				config.HideStepDuration = 500;
				config.VisibleStateDuration = 3000;
				config.Position = MatToastPosition.BottomFullWidth;
			});
		}
	}
}