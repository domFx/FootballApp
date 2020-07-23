using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FootballApp.Core;
using FootballApp.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FootballApp.Api.Controllers {
	[Route("api/[controller]")]
	[Produces("application/json")]
	[ApiController]
	public class TeamController : ControllerBase {
		readonly FootballContext _context;

		public TeamController(FootballContext context) {
			_context = context;
		}

		[HttpGet]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		[ProducesResponseType((int)HttpStatusCode.NoContent)]
		public async Task<ActionResult<List<Team>>> GetAllTeamsAsync() {
			List<Team> teams = await _context.Teams
										.Include(t => t.Country)
										.ToListAsync();

			if (!(teams is null) && teams.Count > 0)
				return Ok(teams);
			else
				return NoContent();
		}

		[HttpGet("country/{code}")]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		[ProducesResponseType((int)HttpStatusCode.NoContent)]
		public async Task<ActionResult<List<Team>>> GetAllTeamsInCountryAsync(string code) {
			List<Team> teams = await _context.Teams
										.Include(t => t.Country)
										.Include(t => t.Competitions)
										.ThenInclude(c => c.Competition)
										.Where(t => t.Country.Code.ToLower().Equals(code.ToLower()))
										.ToListAsync();

			if (!(teams is null) && teams.Count > 0)
				return Ok(teams);
			else
				return NoContent();
		}
	}
}
