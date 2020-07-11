using FootballApp.Core.Models;
using System.Threading.Tasks;

namespace FootballAppApi.Services {
	public interface IAdminService {
		Task UpdateAllCompetitionDataAsync();
		Task UpdateCompetitionDataAsync(string competitionCode, Competition competition = null);
	}
}
