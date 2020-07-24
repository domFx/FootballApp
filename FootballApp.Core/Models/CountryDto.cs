using System;
using System.Collections.Generic;
using System.Text;

namespace FootballApp.Core.Models {
	public class CountryDto : Country {
		public IList<CompetitionDto> Competitions { get; set; }
	}
}
