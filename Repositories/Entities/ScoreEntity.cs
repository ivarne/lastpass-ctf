using System;

namespace Ctf.Repositories.Entities
{
	public class ScoreEntity
	{
		public Guid Id { get; set; }
		public TeamEntity Team { get; set; }
		public DateTime Scored { get; set; }
	}
}