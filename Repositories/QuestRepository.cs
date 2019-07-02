using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ctf.Models.BuisinesModels;

namespace Ctf.Repositories{
    public class QuestRepository{
        public Task<IEnumerable<Quest>> GetQuests(){
            return Task.FromResult<IEnumerable<Quest>>(QUESTS);
        }
        public Task<Quest> GetQuest(Guid id){
            return Task.FromResult<Quest>(QUESTS.FirstOrDefault(q=>q.Id == id));
        }

        private static Quest[] QUESTS = new Quest[]{
                new Quest(
                    Id : Guid.Parse("49bdf307-510b-4429-8539-a62c6a415efb"),
                    Name : "Intro",
                    Points : 1,
                    Description: "Enkel intro oppgave for å komme i gang",
                    Area: "Intro"
                ),
                new Quest(
                    Id : Guid.Parse("49bdf307-510b-4429-8539-a62c6a415efc"),
                    Name : "XSRF",
                    Points : 100,
                    Description: "Hva kan du gjøre med et api som gjør endringer uten ekstra beskyttelse",
                    Area: "Intro"
                ),
                new Quest(
                    Id : Guid.Parse("49bdf307-510b-4429-8539-a62c6a415efd"),
                    Name : "XSS",
                    Points : 1,
                    Description: "Simple chat app",
                    Area: "Intro"
                ),
            };
    }
}