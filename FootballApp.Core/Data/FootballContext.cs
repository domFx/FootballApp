using FootballApp.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballApp.Core {
	public class FootballContext : DbContext {
		public DbSet<Team> Teams { get; set; }
		public DbSet<Fixture> Fixtures { get; set; }
		public DbSet<Competition> Competitions { get; set; }
		public DbSet<Country> Countries { get; set; }
		public DbSet<Lookup> Lookups { get; set; }
		public DbSet<CompetitionTeam> CompetitionTeams { get; set; } 
		
		public FootballContext(
			DbContextOptions<FootballContext> options
		) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			modelBuilder.Entity<Team>().ToTable("Team");
			modelBuilder.Entity<Fixture>().ToTable("Fixture");
			modelBuilder.Entity<Competition>().ToTable("Competition")
						.HasIndex(c => c.Code).IsUnique();
			modelBuilder.Entity<Country>().ToTable("Country")
						.HasIndex(c => c.Code).IsUnique();
			modelBuilder.Entity<Lookup>().ToTable("Lookup");
			modelBuilder.Entity<CompetitionTeam>().ToTable("CompetitionTeam")
						.HasKey(ct => new { ct.CompetitionId, ct.TeamId });
		}
	}
}
