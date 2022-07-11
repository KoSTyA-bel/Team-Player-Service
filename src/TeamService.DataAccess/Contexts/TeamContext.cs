using Microsoft.EntityFrameworkCore;
using TeamService.BusinessLogic.Entities;
using TeamService.DataAccess.Confirurations;

namespace TeamService.DataAccess.Contexts;

public class TeamContext : DbContext
{
    public TeamContext(DbContextOptions<TeamContext> options)
        : base(options)
    { 
    }

    public DbSet<Team> Teams { get; set; }

    public DbSet<Player> Player { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TeamConfiguration());
        modelBuilder.ApplyConfiguration(new PlayerConfiguration());

        modelBuilder.Entity<Player>().HasOne(player => player.Team).WithMany(team => team.Players).HasForeignKey(player => player.TeamId);

        base.OnModelCreating(modelBuilder);
    }
}
