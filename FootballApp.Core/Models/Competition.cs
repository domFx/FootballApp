using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballApp.Core.Models {
	public class Competition {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int CompetitionId { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
		public Country Country { get; set; }
		public List<Team> Teams { get; set; }
	}
}
