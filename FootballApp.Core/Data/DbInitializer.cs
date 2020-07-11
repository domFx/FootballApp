using FootballApp.Core.Models;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;

namespace FootballApp.Core.Data {
	public static class DbInitializer {
		public static void Initialize(FootballContext context) {

			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();

			if (!context.Lookups.Any()) {
				Lookup[] lookups = new Lookup[] {
					new Lookup { SetName = "CSVHeader", Code = "Div", Value = "Competition" },
					new Lookup { SetName = "CSVHeader", Code = "Date", Value = "Date" },
					new Lookup { SetName = "CSVHeader", Code = "Time", Value = "Time" },
					new Lookup { SetName = "CSVHeader", Code = "HomeTeam", Value = "HomeTeam" },
					new Lookup { SetName = "CSVHeader", Code = "AwayTeam", Value = "AwayTeam" }
				};

				context.Lookups.AddRange(lookups);
			}

			if (!context.Countries.Any()) {
				context.Countries.Add(
					new Country() {
						Code = "ENG",
						Name = "England"
					}	
				);

				context.SaveChanges();
			}

			if (!context.Competitions.Any()) {
				Country country = context.Countries.Where(c => c.Code == "ENG").FirstOrDefault();

				Competition[] competitions = new Competition[] {
					new Competition { Code = "E1", Name = "English Championship", Country = country }
				};

				context.Competitions.AddRange(competitions);

				context.SaveChanges();
			}
		}
	}
}
