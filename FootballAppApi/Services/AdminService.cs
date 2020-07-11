using FootballApp.Core;
using FootballApp.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FootballAppApi.Services {
	public class AdminService : IAdminService {

		readonly ILogger<AdminService> _logger;
		readonly FootballContext _context;

		public AdminService(
			ILogger<AdminService> logger,
			FootballContext context
		) {
			_logger = logger;
			_context = context;
		}

		public async Task UpdateAllCompetitionDataAsync() {
			_logger.LogInformation("Updating data for all leagues");
			List<Competition> competitions = await _context.Competitions.ToListAsync();

			if(!(competitions is null)) {
				List<Task> competitionTasks = new List<Task>();

				foreach(Competition competition in competitions) {
					competitionTasks.Add(UpdateCompetitionDataAsync(competition.Code, competition));
				}

				await Task.WhenAll(competitionTasks);
			}
		}

		public async Task UpdateCompetitionDataAsync(string competitionCode, Competition competition = null) {
			_logger.LogInformation($"Updating data for league: {competitionCode}");
			
			string[] data = await GetCSVForCompetitionAsync(competitionCode);

			if (competition is null)
				competition = await _context.Competitions.Where(c => c.Code.Equals(competitionCode)).FirstOrDefaultAsync();
			
			List<Fixture> results = await ParseCompetitionData(data, competition);
			
			if(!(results is null))
				_context.Fixtures.AddRange(results);
	
			await _context.SaveChangesAsync();
		}

		private async Task<string[]> GetCSVForCompetitionAsync(string csvCode) {
#if DEBUG
			return await File.ReadAllLinesAsync("TestData/E1.csv");
#endif
		}

		private async Task<List<Fixture>> ParseCompetitionData(string[] data, Competition competition) {
			List<Fixture> fixtures = null;

			// Check if we have more than one entry (excluding the csv header)
			if(data.Length > 1) {
				List<Lookup> teamFieldsMap = await _context.Lookups.Where(l => l.SetName.Equals("CSVHeader")).ToListAsync();

				Dictionary<string, Team> teams = 
					await _context.Teams.Include(i => i.Competitions)
										.Where(c => c.Competitions.Select(c => c.CompetitionId)
																  .Contains(competition.CompetitionId))
										.ToDictionaryAsync(t => t.AltName, t => t);

				Dictionary<string, int> headerCodes = data[0].Split(',')
															 .Select((val, idx) => new { val, idx })
															 .ToDictionary(p => p.val, p => p.idx);
				
				for(int i = 1; i < data.Length; i++) {
					string[] fixtureData = data[i].Split(',');
					dynamic fixture = new ExpandoObject();

					for(int j = 0; j < fixtureData.Length; j++) {

						foreach(Lookup l in teamFieldsMap) {
							int idx = -1;
							if(headerCodes.ContainsKey(l.Code))
								idx = headerCodes[l.Code];
							
							if (idx >= 0) {
								switch(l.Value) {
									case "Competition":
										fixture.Competition = competition;
										break;
									case "HomeTeam":
									case "AwayTeam":
										if(teams.ContainsKey(fixtureData[j])) {
											((IDictionary<string, object>)fixture).Add(l.Value, teams[fixtureData[j]]);
										} else {
											// Team doesn't exist in Db, create a new one
											Team t = new Team() {
												Name = fixtureData[j],
												AltName = fixtureData[j]
											};

											_context.Teams.Add(t);
											await _context.SaveChangesAsync();
											t = await _context.Teams.Where(t => t.AltName.Equals(fixtureData[j])).FirstOrDefaultAsync();
											teams.Add(t.AltName, t);

											((IDictionary<string, object>)fixture).Add(l.Value, teams[fixtureData[j]]);
										}
										break;
									default:
										((IDictionary<string, object>)fixture).Add(l.Value, fixtureData[j]);
										break;
								}
							}
						}
					}

					fixtures.Add((Fixture)fixture);
				}
			}

			return fixtures;
		}
	}
}
