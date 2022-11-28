using BasketLeagueAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BasketLeagueAPI.Data
{
    public class BasketLeagueDbContext : DbContext
    {
        public BasketLeagueDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Team> Teams { get; set; }

        public DbSet<MatchResult> MatchResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().HasMany(t => t.HomeGames)
                .WithOne(g => g.HomeTeam)
                .HasForeignKey(g => g.HomeTeamId);
            modelBuilder.Entity<Team>().HasMany(t => t.AwayGames)
                .WithOne(g => g.AwayTeam)
                .HasForeignKey(g => g.AwayTeamId).OnDelete(DeleteBehavior.Restrict);
        }

    }
}
