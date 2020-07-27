using System;
using System.Text.Json.Serialization;

namespace FootballApp.Core.Models {
	public class Fixture : FixtureBase {
		public virtual Competition Competition { get; set; }
		public virtual DateTime Date { get; set; }
		public virtual TimeSpan Time { get; set; }
	}
}
