using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace FootballApp.Core.Models {
	public class Country {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int CountryId { get; set; }
		public string Name { get; set; }
		public string Code { get; set; }
		[JsonIgnore]
		public IList<Competition> CountryCompetitions { get; set; }
	}
}
