using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FootballApp.Core.Models {
	public class Competition : CompetitionBase {
		public Country Country { get; set; }
		public IList<CompetitionTeam> CompetitionTeams { get; set; }
	}
}