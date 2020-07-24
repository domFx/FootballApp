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
	public class TeamController : ControllerBase {
		readonly FootballContext _context;

		public TeamController(FootballContext context) {
			_context = context;
		}

		[HttpGet]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		[ProducesResponseType((int)HttpStatusCode.NoContent)]
		public async Task<ActionResult<List<TeamDto>>> GetAllTeamsAsync() {
			List<TeamDto> teams = await _context.Teams
										.Select(t => new TeamDto() {
											TeamId = t.TeamId,
											Name = t.Name,
											AltName = t.AltName,
											Country = t.Country,
											Competitions = t.CompetitionTeams.Select(ct => new TeamCompetitionDto() {
												CompetitionId = ct.Competition.CompetitionId,
												Code = ct.Competition.Code,
												Name = ct.Competition.Name,
											}).ToList()
										})
										.ToListAsync();

			if (!(teams is null) && teams.Any())
				return Ok(teams);
			else
				return NoContent();
		}

		[HttpGet("country/{countryCode}")]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		[ProducesResponseType((int)HttpStatusCode.NoContent)]
		public async Task<ActionResult<List<TeamDto>>> GetAllTeamsInCountryAsync(string countryCode) {
			List<TeamDto> teams = await _context.Teams
										.Select(t => new TeamDto() {
											TeamId = t.TeamId,
											Name = t.Name,
											AltName = t.AltName,
											Country = t.Country,
											Competitions = t.CompetitionTeams.Select(ct => new TeamCompetitionDto() {
												CompetitionId = ct.Competition.CompetitionId,
												Code = ct.Competition.Code,
												Name = ct.Competition.Name,
											}).ToList()
										})
										.Where(t => t.Country.Code.ToLower().Equals(countryCode.ToLower()))
										.ToListAsync();

			if (!(teams is null) && teams.Any())
				return Ok(teams);
			else
				return NoContent();
		}

		[HttpGet("competition/{competitionCode}")]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		[ProducesResponseType((int)HttpStatusCode.NoContent)]
		public async Task<ActionResult<List<TeamDto>>> GetAllTeamsInCompetitionAsync(string competitionCode) {
			List<TeamDto> teams = await _context.Teams
										.Select(t => new TeamDto() {
											TeamId = t.TeamId,
											Name = t.Name,
											AltName = t.AltName,
											Country = t.Country,
											Competitions = t.CompetitionTeams.Select(ct => new TeamCompetitionDto() {
												CompetitionId = ct.Competition.CompetitionId,
												Code = ct.Competition.Code,
												Name = ct.Competition.Name,
											}).ToList()
										})
										.ToListAsync();

			// Todo: Find a way to move this in to the query
			teams = teams.Where(t => t.Competitions.Any(c => c.Code.ToLower().Equals(competitionCode.ToLower()))).ToList();
			
			if (!(teams is null) && teams.Any())
				return Ok(teams);
			else
				return NoContent();
		}
	}
}
