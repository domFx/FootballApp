using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballApp.Core.Models {
	public class Team {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int TeamId { get; set; }
		public string Name { get; set; }
		public string AltName { get; set; }
		[ForeignKey("CountryId")]
		public Country Country { get; set; }
		public IList<CompetitionTeam> Competitions { get; set; }

		public Team() {
			Competitions = new List<CompetitionTeam>();
		}
	}
}
