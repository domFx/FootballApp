using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FootballApp.Core.Models {
	public class Competition {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int CompetitionId { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
		[JsonIgnore]
		public Country Country { get; set; }
		[JsonIgnore]
		public IList<CompetitionTeam> CompetitionTeams { get; set; }
	}
}
