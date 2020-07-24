using FootballApp.Core;
using FootballAppApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FootballAppApi {
	public class Startup {
		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services) {
			services.AddSwaggerGen();

			services.AddDbContext<FootballContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("FootballContext")));

			services.AddTransient<IAdminService, AdminService>();

			services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.IgnoreNullValues = true);
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
			app.UseSwagger();

			app.UseSwaggerUI(c => {
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "FootballApp Api");
				c.DocumentTitle = "Football App Api";
				c.RoutePrefix = string.Empty;
			});
		
			if (env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints => {
				endpoints.MapControllers();
			});
		}
	}
}
