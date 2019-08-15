using System;
using System.Collections.Generic;

namespace Ctf.Repositories.Entities
{
	public class TeamEntity
	{
		public Guid Id { get; set; }
		public string Name { get; set; } = null!;
		public List<ScoreEntity> Scores { get; set; } = null!;
	}
}