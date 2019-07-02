namespace Ctf.Models.BuisinesModels {
    public class TeamScore{
        public TeamScore(Team team, QuestScore questScore)
        {
            Team = team;
            QuestScore = QuestScore;
        }
        public Team Team { get; set; }
        public QuestScore QuestScore { get; set; }
    }
}