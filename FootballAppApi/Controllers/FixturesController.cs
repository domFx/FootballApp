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
	[ApiController]
	public class FixturesController : ControllerBase {
		readonly FootballContext _context;

		public FixturesController(FootballContext context) {
			_context = context;
		}

		[HttpGet("competition/{competitionCode}")]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		[ProducesResponseType((int)HttpStatusCode.NoContent)]
		public async Task<ActionResult<Fixture>> GetFixturesForCompetitionAsync(string competitionCode) {
			List<Fixture> fixtures = await _context.Fixtures
												.Include(f => f.HomeTeam)
												.Include(f => f.AwayTeam)
												.ToListAsync();

			if (!(fixtures is null) && fixtures.Any())
				return Ok(fixtures);
			else
				return NoContent();
		}

	}
}
