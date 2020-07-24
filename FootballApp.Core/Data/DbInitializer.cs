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
					new Lookup { SetName = "CSVHeader", Code = "Div", Value = "Competition", ShortValue = "Competition" },
					new Lookup { SetName = "CSVHeader", Code = "Date", Value = "Date", ShortValue = "DateTime" },
					new Lookup { SetName = "CSVHeader", Code = "Time", Value = "Time", ShortValue = "TimeSpan" },
					new Lookup { SetName = "CSVHeader", Code = "HomeTeam", Value = "HomeTeam", ShortValue = "Team" },
					new Lookup { SetName = "CSVHeader", Code = "AwayTeam", Value = "AwayTeam", ShortValue = "Team" },
					new Lookup { SetName = "CSVHeader", Code = "FTHG", Value = "FullTimeHomeGoals", ShortValue = "int" },
					new Lookup { SetName = "CSVHeader", Code = "FTAG", Value = "FullTimeAwayGoals", ShortValue = "int" },
					new Lookup { SetName = "CSVHeader", Code = "FTR", Value = "FullTimeResult", ShortValue = "string" },
					new Lookup { SetName = "CSVHeader", Code = "HTHG", Value = "HalfTimeHomeGoals", ShortValue = "int" },
					new Lookup { SetName = "CSVHeader", Code = "HTAG", Value = "HalfTimeAwayGoals", ShortValue = "int" },
					new Lookup { SetName = "CSVHeader", Code = "Referee", Value = "Referee", ShortValue = "string" },
					new Lookup { SetName = "CSVHeader", Code = "HS", Value = "HomeTeamShots", ShortValue = "int" },
					new Lookup { SetName = "CSVHeader", Code = "AS", Value = "AwayTeamShots", ShortValue = "int" },
					new Lookup { SetName = "CSVHeader", Code = "HST", Value = "HomeTeamShotsOnTarget", ShortValue = "int" },
					new Lookup { SetName = "CSVHeader", Code = "AST", Value = "AwayTeamShotsOnTarget", ShortValue = "int" },
					new Lookup { SetName = "CSVHeader", Code = "HF", Value = "HomeTeamFouls", ShortValue = "int" },
					new Lookup { SetName = "CSVHeader", Code = "AF", Value = "AwayTeamFouls", ShortValue = "int" },
					new Lookup { SetName = "CSVHeader", Code = "HC", Value = "HomeTeamCorners", ShortValue = "int" },
					new Lookup { SetName = "CSVHeader", Code = "AC", Value = "AwayTeamCorners", ShortValue = "int" },
					new Lookup { SetName = "CSVHeader", Code = "HY", Value = "HomeTeamYellowCards", ShortValue = "int" },
					new Lookup { SetName = "CSVHeader", Code = "AY", Value = "AwayTeamYellowCards", ShortValue = "int" },
					new Lookup { SetName = "CSVHeader", Code = "HR", Value = "HomeTeamRedCards", ShortValue = "int" },
					new Lookup { SetName = "CSVHeader", Code = "AR", Value = "AwayTeamRedCards", ShortValue = "int" },
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
