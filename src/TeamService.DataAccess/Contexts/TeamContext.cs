using Microsoft.EntityFrameworkCore;
using TeamService.BusinessLogic.Entities;
using TeamService.DataAccess.Confirurations;

namespace TeamService.DataAccess.Contexts;

/// <summary>
/// Database context.
/// </summary>
/// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
public class TeamContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TeamContext"/> class.
    /// </summary>
    /// <param name="options">The options.</param>
    public TeamContext(DbContextOptions<TeamContext> options)
        : base(options)
    { 
    }

    /// <summary>
    /// Gets or sets the teams.
    /// </summary>
    /// <value>
    /// The teams.
    /// </value>
    public DbSet<Team> Teams { get; set; }

    /// <summary>
    /// Gets or sets the player.
    /// </summary>
    /// <value>
    /// The player.
    /// </value>
    public DbSet<Player> Players { get; set; }

    /// <inheritdoc/>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TeamConfiguration());
        modelBuilder.ApplyConfiguration(new PlayerConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
