using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace FootballApp.Core.Models {
	public class Country : CountryBase {
		public IList<Competition> Competitions { get; set; }
	}
}
