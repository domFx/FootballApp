using System.Collections.Generic;

namespace FootballApp.Core.Models {
	public class CompetitionDto : CompetitionBase {
		public CountryBase Country { get; set; }
		public IList<CompetitionTeamBase> CompetitionTeams { get; set; }
	}
}
