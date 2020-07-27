using System.ComponentModel.DataAnnotations.Schema;

namespace FootballApp.Core.Models {
	public abstract class FixtureBase {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int FixtureId { get; set; }
		[ForeignKey("HomeTeamId")]
		public Team HomeTeam { get; set; }
		[ForeignKey("AwayTeamId")]
		public Team AwayTeam { get; set; }
		public int FullTimeHomeGoals { get; set; }
		public int FullTimeAwayGoals { get; set; }
		public int HalfTimeHomeGoals { get; set; }
		public int HalfTimeAwayGoals { get; set; }
		public string Referee { get; set; }
		public int HomeTeamShots { get; set; }
		public int AwayTeamShots { get; set; }
		public int HomeTeamShotsOnTarget { get; set; }
		public int AwayTeamShotsOnTarget { get; set; }
		public int HomeTeamFouls { get; set; }
		public int AwayTeamFouls { get; set; }
		public int HomeTeamCorners { get; set; }
		public int AwayTeamCorners { get; set; }
		public int HomeTeamYellowCards { get; set; }
		public int AwayTeamYellowCards { get; set; }
		public int HomeTeamRedCards { get; set; }
		public int AwayTeamRedCards { get; set; }
	}
}
