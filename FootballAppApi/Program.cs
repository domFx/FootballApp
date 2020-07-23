using FootballApp.Core;
using FootballApp.Core.Data;
using FootballAppApi.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace FootballAppApi {
	public class Program {
		public static void Main(string[] args) {
			IHost host = CreateHostBuilder(args).Build();

#if DEBUG
			CreateDbIfNotExists(host);
#endif

			host.Run();
		}

		private static void CreateDbIfNotExists(IHost host) {
			using IServiceScope scope = host.Services.CreateScope();
			IServiceProvider services = scope.ServiceProvider;

			try {
				FootballContext context = services.GetRequiredService<FootballContext>();

				DbInitializer.Initialize(context);

				IAdminService adminService = services.GetRequiredService<IAdminService>();
				adminService.UpdateAllCompetitionDataAsync().GetAwaiter().GetResult();
			} catch (Exception ex) {
				ILogger logger = services.GetRequiredService<ILogger<Program>>();
				logger.LogError(ex, $"An error occurect => {ex.Message}");
			}
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder => {
					webBuilder.UseStartup<Startup>();
				});
	}
}
