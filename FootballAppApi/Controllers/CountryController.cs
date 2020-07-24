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

		public CountryController(FootballContext context) {
			_context = context;
		}

		[HttpGet]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		[ProducesResponseType((int)HttpStatusCode.NoContent)]
		public async Task<ActionResult<List<Country>>> GetAllCountriesAsync() {
			List<Country> countries = await _context.Countries.ToListAsync();

			if (!(countries is null) && countries.Any())
				return Ok(countries);
			else
				return NoContent();
		}

		[HttpGet("withcompetitions")]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		[ProducesResponseType((int)HttpStatusCode.NoContent)]
		public async Task<ActionResult<List<CountryDto>>> GetAllCountriesWithCompetitionsAsync() {
			List<CountryDto> countries = await _context.Countries
												.Include(c => c.CountryCompetitions)
												.Select(c => new CountryDto() {
													Code = c.Code,
													CountryId = c.CountryId, 
													Name = c.Name,
													Competitions = c.CountryCompetitions.Select(cc => new CompetitionDto() {
														CompetitionId = cc.CompetitionId,
														Code = cc.Code,
														Name = cc.Name,
													}).ToList()
												})
												.ToListAsync();

			if (!(countries is null) && countries.Any())
				return Ok(countries);
			else
				return NoContent();
		}
	}
}
