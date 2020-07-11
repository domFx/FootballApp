using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FootballAppApi.Services {
	public class AdminService : IAdminService {

		readonly ILogger<AdminService> _logger;

		public AdminService(
			ILogger<AdminService> logger
		) {
			_logger = logger;
		}

		public async Task UpdateAllLeagueDataAsync() {
			_logger.LogInformation("Updating data for all leagues");
			List<string> leagues = new List<string>();

			List<Task> leagueTasks = new List<Task>();
			foreach(string league in leagues) {
				leagueTasks.Add(UpdateLeagueDataAsync(league));
			}

			await Task.WhenAll(leagueTasks);
		}

		public async Task UpdateLeagueDataAsync(string league) {
			_logger.LogInformation($"Updating data for league: {league}");
			string[] data = await GetCSVForLeagueAsync(league);
			List<object> results = ParseLeagueData(data);
			return;
		}

		private async Task<string[]> GetCSVForLeagueAsync(string csvCode) {
#if DEBUG
			return await File.ReadAllLinesAsync("TestData/E1.csv");
#endif
		}

		private List<object> ParseLeagueData(string[] data) {
			List<object> results = null;
			// Check if we have more than one entry (excluding the csv header)
			if(data.Length > 1) {
				string[] headers = data[0].Split(',');
				for(int i = 1; i < data.Length; i++) {
					string[] result = data[i].Split(',');
				}
			}

			return results;
		}
	}
}
