using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ctf.Models;
using Ctf.Models.ViewModels;
using Ctf.Repositories;

namespace Ctf.Controllers{
    public class ScoreboardController : Controller{
        private readonly ScoringRepository _scoringRepository;
        private readonly QuestRepository _questRepository;
        
        public ScoreboardController(ScoringRepository scoringRepository, QuestRepository questRepository)
        {
            _scoringRepository = scoringRepository;
            _questRepository = questRepository;
            
        }
        public async Task<IActionResult> Index()
        {
            var model = new ScoreboardViewModel(
                Quests: await _questRepository.GetQuests(),
                Teams: await _scoringRepository.GetHighSocres()
                );
            return View(model);
        }
    }
}