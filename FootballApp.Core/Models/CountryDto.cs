using System.Collections.Generic;

namespace FootballApp.Core.Models {
	public class CountryDto : CountryBase {
		public IList<CompetitionBase> Competitions { get; set; }
	}
}
