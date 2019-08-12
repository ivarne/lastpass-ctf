using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Ctf.Models;
using Ctf.Repositories;

namespace Ctf.Areas.ByPass
{
	[Area("ByPass")]
	public class ByPassController : Controller
	{
		public ByPassController(ScoringRepository scoringRepository)
		{
			_scoringRepository = scoringRepository;
		}
		private readonly ScoringRepository _scoringRepository;
		public IActionResult Index()
		{
			return View();
		}
		[Authorize(Roles = "admin")]
		[HttpGet]
		[HttpPost]
		public async Task<IActionResult> SetFlag(string team)
		{
			if (ModelState.IsValid)
			{
				// _scoringRepository.
				return RedirectToAction("Index");
			}
			return RedirectToAction("Index");
		}

	}
}