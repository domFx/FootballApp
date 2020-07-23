using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballApp.Core.Models {
	public class Fixture {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int FixtureId { get; set; }
		[ForeignKey("HomeTeamId")]
		public Team HomeTeam { get; set; }
		[ForeignKey("AwayTeamId")]
		public Team AwayTeam { get; set; }
		public DateTime Date { get; set; }
		public TimeSpan Time { get; set; }
		public Competition Competition { get; set; }

		public Fixture() { }
	}
}
