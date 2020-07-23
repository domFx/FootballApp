using System;
using System.Collections.Generic;
using System.Text;

namespace FootballApp.Core.Models {
	public class CompetitionTeam {
		public int TeamId { get; set; }
		public Team Team { get; set; }
		public int CompetitionId { get; set; }
		public Competition Competition { get; set; }
	}
}
