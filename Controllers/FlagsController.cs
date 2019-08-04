using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ctf.Models.ViewModels;
using Ctf.Models.BusinessModels;
using Ctf.Repositories;

namespace Ctf.Controllers{
    public class FlagsController : Controller{
        private QuestRepository _questRepository {get; set;}
        public FlagsController(QuestRepository questRepository)
        {
            this._questRepository = questRepository;
        }
        public async Task<IActionResult> Index(){
            return View(new FlagViewModel(await _questRepository.GetQuests()));
        }
    }
}