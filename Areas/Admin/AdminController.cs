using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using System.Security.Claims;
using Ctf.Models;
using Ctf.Repositories;

namespace Ctf.Areas.Admin
{
	[Area("Admin")]
	public class AdminController : Controller
	{
		private FlagRepository _flagRepository;
		public AdminController(FlagRepository flagRepository)
		{
			_flagRepository = flagRepository;
		}
		public IActionResult Index()
		{
			var flag = "CTF{You_are_NOT_admin}";

			return View(new AdminViewModel(flag, "admin"));
		}
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> Index(string team)
		{
			var flag = await _flagRepository.GetFlag("49bdf307-510b-4429-8539-a62c6a415efd");
			return View(new AdminViewModel(flag, team));
		}
		[Authorize(Roles = "admin")]
		public IActionResult Admin()
		{
			return View();
		}
	}
}