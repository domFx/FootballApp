using System.Collections.Generic;
using System.Linq;

namespace FootballApp.Core.Models {
	public class TeamDto : Team {
		public List<TeamCompetitionDto> Competitions { get; set; }

		public TeamDto(Team t) {
			TeamId = t.TeamId;
			Name = t.Name;
			AltName = t.AltName;
			Country = t.Country;
			Competitions = t.CompetitionTeams.Select(ct => new TeamCompetitionDto(ct)).ToList();
		}

		public TeamDto() { }
	}
}
