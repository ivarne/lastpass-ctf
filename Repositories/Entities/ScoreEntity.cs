using System;

namespace Ctf.Repositories.Entities
{
	public class ScoreEntity
	{
		public Guid Id { get; set; }
		public Guid QuestId {get; set; }
		public TeamEntity Team { get; set; } = null!;
		public DateTime Scored { get; set; }
	}
}