using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FootballApp.Core.Models {
	public class Team {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int TeamId { get; set; }
		public string Name { get; set; }
		public string AltName { get; set; }
		[ForeignKey("CountryId")]
		public Country Country { get; set; }
		[JsonIgnore]
		public IList<CompetitionTeam> CompetitionTeams { get; set; } = new List<CompetitionTeam>();
	}
}
