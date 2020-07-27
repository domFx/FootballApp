using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballApp.Core.Models {
	public class Team : TeamBase {
		[ForeignKey("CountryId")]
		public Country Country { get; set; }
		public IList<CompetitionTeam> CompetitionTeams { get; set; }
	}
}
