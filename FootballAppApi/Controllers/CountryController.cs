using FootballApp.Core;
using FootballApp.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

			if (!(countries is null) && countries.Count > 0)
				return Ok(countries);
			else
				return NoContent();
		}
	}
}
