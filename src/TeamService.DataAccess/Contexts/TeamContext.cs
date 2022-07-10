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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TeamConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
