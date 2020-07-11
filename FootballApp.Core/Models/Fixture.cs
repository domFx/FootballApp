using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FootballApp.Core.Models {
	public class Fixture {
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int FixtureId { get; set; }
		public Team HomeTeam { get; set; }
		public Team AwayTeam { get; set; }
		public DateTime Date { get; set; }
		public Division Division { get; set; }
	}
}
