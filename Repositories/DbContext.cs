using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Ctf.Repositories.Entities;

namespace Ctf.Repositories
{
	public class CtfDbContext : DbContext
	{
		public CtfDbContext(DbContextOptions<CtfDbContext> options)
		: base(options)
		{ }
		public DbSet<TeamEntity> Teams { get; set; } = null!;
		public DbSet<ScoreEntity> Scores { get; set; } = null!;
	}
}