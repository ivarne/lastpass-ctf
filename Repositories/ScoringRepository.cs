using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ctf.Models.BusinessModels;
using Microsoft.EntityFrameworkCore;

namespace Ctf.Repositories
{
	public class ScoringRepository
	{
		private readonly QuestRepository _questRepository;
		private readonly FlagRepository _flagRepository;
		private readonly CtfDbContext _ctfDbContext;
		public ScoringRepository(QuestRepository qr, FlagRepository fr, CtfDbContext ctx)
		{
			_questRepository = qr;
			_flagRepository = fr;
			_ctfDbContext = ctx;
		}
		public async Task<IEnumerable<Team>> GetHighSocres()
		{
			var now = DateTime.Now;
			var teams = _ctfDbContext.Teams.Include(t => t.Scores);
			return await teams.Select(t=>new Team(t.Name, t.Scores.Select(s=>new QuestScore(s.QuestId,s.Scored)))).ToListAsync();
		}
		public async Task AddTeamScore(string teamname, Guid questId)
		{
			var team = await _ctfDbContext.Teams.FirstOrDefaultAsync(t=>t.Name == teamname);
			if(team == null){
				team = new Entities.TeamEntity{Id=Guid.NewGuid(), Name = teamname};
				_ctfDbContext.Add(team);
			}
			_ctfDbContext.Add(
				new Entities.ScoreEntity{
					Id=Guid.NewGuid(),
					QuestId = questId,
					Scored = DateTime.Now,
					Team = team
					}
				);
			await _ctfDbContext.SaveChangesAsync();
		}

	}

}