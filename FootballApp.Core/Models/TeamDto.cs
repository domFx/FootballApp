using System.Collections.Generic;

namespace FootballApp.Core.Models {
	public class TeamDto : TeamBase {
		public CountryBase Country { get; set; }
		public IList<CompetitionTeamBase> Competitions { get; set; }
	}
}
