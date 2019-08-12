using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
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
			var teams = _ctfDbContext.Teams.Include(t => t.Scores)
		}

		public async Task<bool> TrySetFlag(string team, Guid questId, string flag)
		{
			var realFlag = await _flagRepository.GetFlag(questId);
			if (CryptographicOperations.FixedTimeEquals(Encoding.Unicode.GetBytes(realFlag), Encoding.Unicode.GetBytes(flag)))
			{
				_ctfDbContext.Scores.Add(new Entities.ScoreEntity { Id = Guid.NewGuid(), Scored = DateTime.Now });
				await _ctfDbContext.SaveChangesAsync();
				return true;
			}
			return false;
		}

		private async Task<IEnumerable<QuestScore>> GetFakeScores()
		{
			var random = new Random();
			var quests = await _questRepository.GetQuests();

			return quests
				.Where(q => random.NextDouble() > 0.4)
				.Select(q => new QuestScore(q.Id, DateTime.Now.AddHours(-random.NextDouble())))
				.ToList();
		}
		private async Task<IEnumerable<Team>> GetFakeTeams()
		{

			var names = new string[] { "My team", "Your team", "Our Team" };
			var ret = new List<Team>();
			foreach (var name in names)
			{
				Console.WriteLine(name);
				ret.Add(new Team(name, await GetFakeScores()));
			}
			Console.WriteLine(ret);
			return ret;
		}
	}

}