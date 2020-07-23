using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballAppApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FootballAppApi.Controllers {
	[ApiController]
	[Route("api/[controller]")]
	public class AdminController : ControllerBase {
		readonly ILogger<AdminController> _logger;
		readonly IAdminService _admin;

		public AdminController(
			ILogger<AdminController> logger,
			IAdminService admin
		) {
			_logger = logger;
			_admin = admin;
		}

		[HttpGet]
		public async Task<IActionResult> CheckUpdateLatestData() {
			await _admin.UpdateAllCompetitionDataAsync();
			return Ok();
		}
	}
}
