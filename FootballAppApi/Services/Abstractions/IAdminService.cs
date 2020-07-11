using System.Threading.Tasks;

namespace FootballAppApi.Services {
	public interface IAdminService {
		Task UpdateAllLeagueDataAsync();
		Task UpdateLeagueDataAsync(string league);
	}
}
