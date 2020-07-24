namespace FootballApp.Core.Models {
	public class TeamCompetitionDto : Competition {
		public TeamCompetitionDto(CompetitionTeam ct) {
			CompetitionId = ct.Competition.CompetitionId;
			Code = ct.Competition.Code;
			Name = ct.Competition.Name;
		}

		public TeamCompetitionDto() { }
	}
}
