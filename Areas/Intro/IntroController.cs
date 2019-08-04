using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ctf.Models;
using Ctf.Repositories;

namespace Ctf.Areas.Intro{
    [Area("Intro")]
    public class IntroController : Controller{
        private readonly FlagRepository _flagRepository;
        private readonly QuestRepository _questRepository;
        public IntroController(FlagRepository flagRepository, QuestRepository questRepository)
        {
            _flagRepository = flagRepository;
            _questRepository = questRepository;
        }
        public async Task<IActionResult> Index(){

            return View(new IndexViewModel( await _flagRepository.GetFlag("49bdf307-510b-4429-8539-a62c6a415efb")));
        }
    }
}