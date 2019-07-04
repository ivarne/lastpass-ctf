using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ctf.Models.BuisinesModels;

namespace Ctf.Repositories{
    public class ScoringRepository{
        private QuestRepository _questRepository { get; set; }
        public ScoringRepository(QuestRepository qr)
        {
            _questRepository = qr;
        }
        public async Task<IEnumerable<Team>> GetHighSocres(){
            var now = DateTime.Now;
            return (await GetFakeTeams()).OrderByDescending(t=>t.QuestScores.Sum(qs=>now.Subtract(qs.Finished).Minutes)).ToList();
        }

        private async Task<IEnumerable<QuestScore>> GetFakeScores(){
            var random = new Random();
            var quests = await _questRepository.GetQuests();

            return quests
                .Where(q => random.NextDouble() > 0.4)
                .Select(q => new QuestScore(q.Id, DateTime.Now.AddHours(-random.NextDouble())))
                .ToList();
        }
        private  async Task<IEnumerable<Team>> GetFakeTeams(){

            var names = new string[]{"My team","Your team", "Our Team"};
            var ret = new List<Team>();
            foreach(var name in names){
                Console.WriteLine(name);
                ret.Add(new Team(name, await GetFakeScores()));
            }
            Console.WriteLine(ret);
            return ret;
        }
    }
    
}