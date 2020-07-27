using AutoMapper;
using FootballApp.Core.Models;

namespace FootballApp.Api {
	public class AutoMapperProfile : Profile {
		public AutoMapperProfile() {
			CreateMap<Competition, CompetitionDto>();
			CreateMap<CompetitionTeam, CompetitionTeamDto>();
			CreateMap<Country, CountryDto>();
			CreateMap<Fixture, FixtureDto>()
					.ForMember(d => d.DateAndTime, opt => opt.MapFrom(s => s.Date + s.Time));
			CreateMap<Team, TeamDto>();
		}
	}
}
