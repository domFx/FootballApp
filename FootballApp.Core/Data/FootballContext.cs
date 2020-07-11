using FootballApp.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace FootballApp.Core {
	public class FootballContext : DbContext {
		public DbSet<Team> Teams { get; set; }
		public DbSet<Fixture> Fixtures { get; set; }
		public DbSet<Competition> Competitions { get; set; }
		public DbSet<Country> Countries { get; set; }
		public DbSet<Lookup> Lookups { get; set; }

		public FootballContext(
			DbContextOptions<FootballContext> options
		) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			modelBuilder.Entity<Team>().ToTable("Team");
			modelBuilder.Entity<Fixture>().ToTable("Fixture");
			modelBuilder.Entity<Competition>().ToTable("Competition");
			modelBuilder.Entity<Country>().ToTable("Country");
			modelBuilder.Entity<Lookup>().ToTable("Lookup");
		}
	}
}
