using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Ctf.Models.ViewModels;
using Ctf.Utils;

namespace Ctf.Controllers
{
	public class AccountController : Controller
	{
		[HttpGet]
		public IActionResult Login()
		{
			return View(new LoginViewModel());
		}
		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model)
		{

			if (ModelState.IsValid)
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, model.TeamName),
					new Claim(ClaimTypes.Role, "Team"),
				};
				if (model._isAdmin)
				{
					claims.Add(new Claim(ClaimTypes.Role, "admin"));
				}
				else if ("admin".Equals(model.TeamName, StringComparison.InvariantCultureIgnoreCase))
				{
					throw new Exception("Team can't be named Admin");
				}

				var claimsIdentity = new ClaimsIdentity(
					claims, Constants.COOKIE_NAME);

				var authProperties = new AuthenticationProperties
				{
					//AllowRefresh = <bool>,
					// Refreshing the authentication session should be allowed.

					//ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
					// The time at which the authentication ticket expires. A 
					// value set here overrides the ExpireTimeSpan option of 
					// CookieAuthenticationOptions set with AddCookie.

					//IsPersistent = true,
					// Whether the authentication session is persisted across 
					// multiple requests. When used with cookies, controls
					// whether the cookie's lifetime is absolute (matching the
					// lifetime of the authentication ticket) or session-based.

					//IssuedUtc = <DateTimeOffset>,
					// The time at which the authentication ticket was issued.

					//RedirectUri = <string>
					// The full path or absolute URI to be used as an http 
					// redirect response value.
				};

				await HttpContext.SignInAsync(
					Constants.COOKIE_NAME,
					new ClaimsPrincipal(claimsIdentity),
					authProperties);
				return Redirect("/");
			}
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(Constants.COOKIE_NAME);
			return Redirect("/");
		}
	}
}