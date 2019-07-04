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
                Console.WriteLine($"\nScore:{Name}");
                var score = QuestScores.Sum(qs => qs.Score);
                Console.WriteLine($"Score {Name}: {score}\n");
                return score;
            }
        }
        public QuestScore? GetScore(Guid QuestId){
            Console.WriteLine($"GetScore: {QuestScores.Count()}");
            var score = QuestScores.FirstOrDefault(qs=>qs.QuestId == QuestId);
            Console.WriteLine($"GetScore: {QuestId} {score?.QuestId.ToString().TakeLast(1).First()??' '}");
            Console.WriteLine($"GetScore: {QuestScores.Count()}");
            return score;
        }
    }
}