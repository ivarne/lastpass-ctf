using System;
using System.Collections.Generic;

using Ctf.Models.BusinessModels;

namespace Ctf.Models.ViewModels{
    public class FlagViewModel{
        public FlagViewModel(IEnumerable<Quest> Quests)
        {
            this.Quests = Quests;
        }
        public IEnumerable<Quest> Quests { get; set; }
    }
}