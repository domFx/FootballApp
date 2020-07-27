using System;

namespace FootballApp.Core.Models {
	public class FixtureDto : FixtureBase {
		public DateTime DateAndTime { get; set; } 
		public CompetitionBase Competition { get; set; }
	}
}
