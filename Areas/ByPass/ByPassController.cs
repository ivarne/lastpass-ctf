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
		public async Task<IActionResult> SetFlag(string team)
		{
			if (ModelState.IsValid)
			{
				await _scoringRepository.AddTeamScore(team, Guid.Parse("e99b999f-c48b-4dba-a755-030574dfad0d"));
				return RedirectToAction("Index");
			}
			return RedirectToAction("Index");
		}

	}
}