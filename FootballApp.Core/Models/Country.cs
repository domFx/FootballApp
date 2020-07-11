using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FootballApp.Core.Models {
	public class Country {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int CountryId { get; set; }
		public string Name { get; set; }
		public string Code { get; set; }
		public List<Competition> Competitions { get; set; }
	}
}
