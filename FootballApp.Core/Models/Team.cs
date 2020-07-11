﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FootballApp.Core.Models {
	public class Team {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int TeamId { get; set; }
		public string Name { get; set; }
		public string AltName { get; set; }
		public List<Competition> Competitions{ get; set; }
	}
}
