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
	[ApiController]
	public class FixturesController : ControllerBase {
		readonly FootballContext _context;
		readonly IMapper _mapper;

		public FixturesController(
			FootballContext context,
			IMapper mapper
		) {
			_context = context;
			_mapper = mapper;
		}

		[HttpGet("competition/{competitionCode}")]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		[ProducesResponseType((int)HttpStatusCode.NoContent)]
		public async Task<ActionResult<FixtureDto>> GetFixturesForCompetitionAsync(string competitionCode) {
			List<FixtureDto> fixtures = await _context.Fixtures
												.Include(f => f.HomeTeam)
												.Include(f => f.AwayTeam)
												.Include(f => f.Competition)
												.Select(f => _mapper.Map<FixtureDto>(f))
												.ToListAsync();

			if (!(fixtures is null) && fixtures.Any())
				return Ok(fixtures);
			else
				return NoContent();
		}
	}
}
