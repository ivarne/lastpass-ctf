using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ctf.Models;
using Ctf.Repositories;

namespace Ctf.Areas.CookieJar
{
	[Area("CookieJar")]
	public class CookieJarController : Controller
	{
		private readonly FlagRepository _flagRepository;
		public CookieJarController(FlagRepository flagRepository)
		{
			_flagRepository = flagRepository;
		}
		public async Task<IActionResult> Index()
		{
			var flag = "";
			if (Request.Cookies["jar"] == "admin=true")
				flag = await _flagRepository.GetFlag("bec30cd6-315e-42a0-a450-a3fc61a0a0f6");
			Response.Cookies.Append("jar", "admin=false", new Microsoft.AspNetCore.Http.CookieOptions
			{
				SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict,
				MaxAge = TimeSpan.FromMinutes(2),
			});
			return View(new ViewModel(flag));
		}
	}
}