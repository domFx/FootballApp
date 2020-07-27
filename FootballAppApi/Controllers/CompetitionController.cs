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
	public class CompetitionController : ControllerBase {
		readonly FootballContext _context;
		readonly IMapper _mapper;

		public CompetitionController(
			FootballContext context,
			IMapper mapper
		) {
			_context = context;
			_mapper = mapper;
		}

		[HttpGet]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		[ProducesResponseType((int)HttpStatusCode.NoContent)]
		public async Task<ActionResult<List<CompetitionDto>>> GetAllCompetitionsAsync() {
			List<CompetitionDto> competitions = await _context.Competitions
															.Select(c => _mapper.Map<CompetitionDto>(c))
															.ToListAsync();

			if (!(competitions is null) && competitions.Any())
				return Ok(competitions);
			else
				return NoContent();
		}

		[HttpGet("code/{competitionCode}")]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		[ProducesResponseType((int)HttpStatusCode.NoContent)]
		public async Task<ActionResult<CompetitionDto>> GetAllCompetitionByCodeAsync(string competitionCode) {
			CompetitionDto competition = await _context.Competitions
														.Where(c => c.Code.ToLower().Equals(competitionCode))
														.Select(c => _mapper.Map<CompetitionDto>(c))
														.FirstOrDefaultAsync();

			if (!(competition is null))
				return Ok(competition);
			else
				return NoContent();
		}

		[HttpGet("id/{competitionId:int}")]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		[ProducesResponseType((int)HttpStatusCode.NoContent)]
		public async Task<ActionResult<CompetitionDto>> GetAllCompetitionByIdAsync(int competitionId) {
			CompetitionDto competition = await _context.Competitions
														.Where(c => c.CompetitionId == competitionId)
														.Select(c => _mapper.Map<CompetitionDto>(c))
														.FirstOrDefaultAsync();

			if (!(competition is null))
				return Ok(competition);
			else
				return NoContent();
		}

		[HttpGet("code/{competitionCode}/teams")]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		[ProducesResponseType((int)HttpStatusCode.NoContent)]
		public async Task<ActionResult<List<TeamDto>>> GetTeamsInCompetitionByCodeAsync(string competitionCode) {
			List<TeamDto> teams = await _context.Competitions
								.Include(t => t.CompetitionTeams)
								.ThenInclude(ct => ct.Team)
								.Where(c => c.Code.ToLower().Equals(competitionCode))
								.Select(c => 
									c.CompetitionTeams
										.OrderBy(t => t.Team.Name)
										.Select(ct => _mapper.Map<TeamDto>(ct.Team))
										.ToList()
								)
								.FirstOrDefaultAsync();

			if (!(teams is null) && teams.Any())
				return Ok(teams);
			else
				return NoContent();
		}

		[HttpGet("id/{competitionId:int}/teams")]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		[ProducesResponseType((int)HttpStatusCode.NoContent)]
		public async Task<ActionResult<List<TeamDto>>> GetTeamsInCompetitionByIdAsync(int competitionId) {
			List<TeamDto> teams = await _context.Competitions
											.Include(t => t.CompetitionTeams)
											.ThenInclude(ct => ct.Team)
											.Where(c => c.CompetitionId == competitionId)
											.Select(c =>
												c.CompetitionTeams
													.OrderBy(t => t.Team.Name)
													.Select(ct => _mapper.Map<TeamDto>(ct.Team))
													.ToList()
											)
											.FirstOrDefaultAsync();

			if (!(teams is null) && teams.Any())
				return Ok(teams);
			else
				return NoContent();
		}
	}
}
