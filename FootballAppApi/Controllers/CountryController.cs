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
		public async Task<ActionResult<List<CountryDto>>> GetAllCountriesAsync() {
			List<CountryDto> countries = await _context.Countries
								.Select(c => _mapper.Map<CountryDto>(c))
								.ToListAsync();
			
			if (!(countries is null) && countries.Any())
				return Ok(countries);
			else
				return NoContent();
		}

		[HttpGet("code/{countryCode}")]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		[ProducesResponseType((int)HttpStatusCode.NoContent)]
		public async Task<ActionResult<CountryDto>> GetCountryByCodeAsync(string countryCode) {
			CountryDto country = await _context.Countries
											.Where(c => countryCode.ToLower().Equals(c.Code.ToLower()))
											.Select(c => _mapper.Map<CountryDto>(c))
											.FirstOrDefaultAsync();

			if (!(country is null))
				return Ok(country);
			else
				return NoContent();
		}

		[HttpGet("id/{countryId:int}")]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		[ProducesResponseType((int)HttpStatusCode.NoContent)]
		public async Task<ActionResult<CountryDto>> GetCountryByIdAsync(int countryId) {
			CountryDto country = await _context.Countries
											.Where(c => countryId == c.CountryId)
											.Select(c => _mapper.Map<CountryDto>(c))
											.FirstOrDefaultAsync();

			if (!(country is null))
				return Ok(country);
			else
				return NoContent();
		}

		[HttpGet("code/{countryCode}/teams")]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		[ProducesResponseType((int)HttpStatusCode.NoContent)]
		public async Task<ActionResult<List<TeamDto>>> GetAllTeamsByCodeAsync(string countryCode) {
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

		[HttpGet("id/{countryId:int}/teams")]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		[ProducesResponseType((int)HttpStatusCode.NoContent)]
		public async Task<ActionResult<List<TeamDto>>> GetAllTeamsByIdAsync(int countryId) {
			List<TeamDto> teams = await _context.Teams
										.Include(t => t.Country)
										.Where(t => t.Country.CountryId == countryId)
										.Select(t => _mapper.Map<TeamDto>(t))
										.ToListAsync();

			if (!(teams is null) && teams.Any())
				return Ok(teams);
			else
				return NoContent();
		}

		[HttpGet("code/{countryCode}/competitions")]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		[ProducesResponseType((int)HttpStatusCode.NoContent)]
		public async Task<ActionResult<List<CompetitionDto>>> GetAllCompetitionsByCodeAsync(string countryCode) {
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
		
		[HttpGet("id/{countryId:int}/competitions")]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		[ProducesResponseType((int)HttpStatusCode.NoContent)]
		public async Task<ActionResult<List<CompetitionDto>>> GetAllCompetitionsByIdAsync(int countryId) {
			List<CompetitionDto> competitions = await _context.Competitions
										.Include(t => t.Country)
										.Where(t => t.Country.CountryId == countryId)
										.Select(t => _mapper.Map<CompetitionDto>(t))
										.ToListAsync();

			if (!(competitions is null) && competitions.Any())
				return Ok(competitions);
			else
				return NoContent();
		}
	}
}