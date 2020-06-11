using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace ERPForServiceActivity.App.Controllers {
	public class LoginController : Controller {
		[HttpGet("Login")]
		public IActionResult Login(
			[FromQuery] string returnUrl) {

			if(User.Identity.IsAuthenticated) {
				return LocalRedirect(returnUrl ?? Url.Content("~/"));
			}

			return Challenge();
		}

		[HttpGet("Logout")]
		public async Task<IActionResult> Logout(
			[FromQuery] string returnUrl) {

			if(!User.Identity.IsAuthenticated) {
				return LocalRedirect(returnUrl ?? Url.Content("~/"));
			}

			await HttpContext.SignOutAsync(
				CookieAuthenticationDefaults.AuthenticationScheme)
				.ConfigureAwait(false);

			return LocalRedirect(returnUrl ?? Url.Content("~/"));
		}
	}
}
