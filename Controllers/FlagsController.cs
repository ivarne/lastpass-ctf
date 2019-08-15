using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


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

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Index(
            SubmitFlagViewModel model,
            [FromServices] FlagRepository _flagRepository,
            [FromServices] ScoringRepository _scoreRepository
            ){
            if(ModelState.IsValid){
                var quest = await _questRepository.GetQuest(model.QuestId);
                if(quest != null){
                    var flag = await _flagRepository.GetFlag(quest);
                    if(CryptographicOperations.FixedTimeEquals(Encoding.Unicode.GetBytes(flag), Encoding.Unicode.GetBytes(model.Flag))){
                        await _scoreRepository.AddTeamScore(User.Identity.Name!, quest.Id);
                        return RedirectToAction("Index", "Scoreboard");
                    }
                }
            }
            return RedirectToAction("Index");
        }
    }
}