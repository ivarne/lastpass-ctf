using System;
using System.Collections.Generic;

using Ctf.Models.BusinessModels;

namespace Ctf.Models.ViewModels{
    public class ScoreboardViewModel{
        public ScoreboardViewModel(IEnumerable<Quest> Quests, IEnumerable<Team> Teams)
        {
            this.Quests = Quests;
            this.Teams = Teams;
        }
        public IEnumerable<Quest> Quests { get; set; }
        public IEnumerable<Team> Teams { get; set; }
    }
}