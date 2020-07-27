namespace FootballApp.Core.Models {
	public class CompetitionTeamDto : CompetitionTeamBase {
		public TeamBase Team { get; set; }
		public CompetitionBase Competition { get; set; }
	}
}
