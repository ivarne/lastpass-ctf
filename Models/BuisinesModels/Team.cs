using System;
using System.Collections.Generic;
using System.Linq;

namespace Ctf.Models.BuisinesModels{
    public class Team {
        public Team(string Name, IEnumerable<QuestScore> QuestScores){
            this.Name = Name;
            this.QuestScores = QuestScores;
        }
        public string Name { get; set; }
        public IEnumerable<QuestScore> QuestScores{ get; set; }

        public int TotalScore
        {
            get{
                var score = QuestScores.Sum(qs => qs.Score);
                Console.WriteLine($"Score {Name}: {score}");
                return score;
            }
        }
        public QuestScore? GetScore(Guid id){
            var score = QuestScores.FirstOrDefault(qs=>qs.QuestId == id);
            Console.WriteLine($"GetScore: {id} {score?.QuestId.ToString().TakeLast(1).First()??' '}");
            return score;
        }
    }
}