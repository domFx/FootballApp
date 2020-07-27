using AutoMapper;
using FootballApp.Core;
using FootballApp.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FootballApp.Api.Controllers {
	[Route("api/[controller]")]
	[Produces("application/json")]
	[ApiController]
	public class CountryController : ControllerBase {
		readonly FootballContext _context;
		readonly IMapper _mapper;

		public CountryController(
			FootballContext context,
			IMapper mapper		
		) {
			_context = context;
			_mapper = mapper;
		}

		[HttpGet]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		[ProducesResponseType((int)HttpStatusCode.NoContent)]
		public async Task<ActionResult<CountryDto>> GetCountryAsync(
			[FromQuery(Name="code")] string countryCode = "",
			[FromQuery(Name="id")] int countryId = 0
		) {
			CountryDto country = await _context.Countries
											.Where(c => countryId == 0 || countryId == c.CountryId)
											.Where(c => string.IsNullOrEmpty(countryCode) || countryCode.ToLower().Equals(c.Code.ToLower()))
											.Select(c => _mapper.Map<CountryDto>(c))
											.FirstOrDefaultAsync();

			if (!(country is null))
				return Ok(country);
			else
				return NoContent();
		}

		[HttpGet("{countryCode}/teams")]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		[ProducesResponseType((int)HttpStatusCode.NoContent)]
		public async Task<ActionResult<List<TeamDto>>> GetAllTeamsAsync(string countryCode) {
			List<TeamDto> teams = await _context.Teams
										.Include(t => t.Country)
										.Where(t => t.Country.Code.ToLower().Equals(countryCode.ToLower()))
										.Select(t => _mapper.Map<TeamDto>(t))
										.ToListAsync();

			if (!(teams is null) && teams.Any())
				return Ok(teams);
			else
				return NoContent();
		}

		[HttpGet("{countryCode}/competitions")]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		[ProducesResponseType((int)HttpStatusCode.NoContent)]
		public async Task<ActionResult<List<CompetitionDto>>> GetAllCompetitionsAsync(string countryCode) {
			List<CompetitionDto> competitions = await _context.Competitions
										.Include(t => t.Country)
										.Where(t => t.Country.Code.ToLower().Equals(countryCode.ToLower()))
										.Select(t => _mapper.Map<CompetitionDto>(t))
										.ToListAsync();

			if (!(competitions is null) && competitions.Any())
				return Ok(competitions);
			else
				return NoContent();
		}
	}
}
