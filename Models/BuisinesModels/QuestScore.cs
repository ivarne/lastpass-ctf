using System;

namespace Ctf.Models.BuisinesModels{
    public class QuestScore{
        public QuestScore(Guid QuestId, DateTime Finished)
        {
            this.QuestId = QuestId;
            this.Finished = Finished;
        }
        public Guid QuestId { get; set; }
        public DateTime Finished { get; set;}
        public int Score
        {
            get
            {
                Console.WriteLine($"{QuestId}: {DateTime.Now.ToString("HH:mm:ss")} - {Finished.ToString("HH:mm:ss")} = {(int)DateTime.Now.Subtract(Finished).TotalMinutes}");
                return (int)DateTime.Now.Subtract(Finished).TotalMinutes;
            }
        }
    }
}