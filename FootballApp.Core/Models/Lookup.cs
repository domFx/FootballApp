using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FootballApp.Core.Models {
	public class Lookup {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int LookupId { get; set; }
		public string SetName { get; set; }
		public string Code { get; set; }
		public string Value { get; set; }
	}
}
