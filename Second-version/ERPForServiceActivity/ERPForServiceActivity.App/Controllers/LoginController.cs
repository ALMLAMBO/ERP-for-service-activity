using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace ERPForServiceActivity.App.Controllers {
    public class LoginController : Controller {
		[HttpGet("Login")]
		public IActionResult Login([FromQuery] string returnUrl) {
			if (User.Identity.IsAuthenticated) {
				return LocalRedirect(returnUrl ?? Url.Content("~/"));
			}

			return Challenge();
		}

		[HttpGet("Logout")]
		public async Task<IActionResult> Logout(
			[FromQuery] string returnUrl) {

			if (!User.Identity.IsAuthenticated) {
				return LocalRedirect(returnUrl ?? Url.Content("~/"));
			}

			await HttpContext.SignOutAsync(
				CookieAuthenticationDefaults.AuthenticationScheme);

			return LocalRedirect(returnUrl ?? Url.Content("~/"));
		}
	}
}