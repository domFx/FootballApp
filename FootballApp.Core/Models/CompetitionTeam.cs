namespace FootballApp.Core.Models {
	public class CompetitionTeam : CompetitionTeamBase {
		public Team Team { get; set; }
		public Competition Competition { get; set; }
	}
}
