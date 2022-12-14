using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamService.BusinessLogic.Entities;

namespace TeamService.DataAccess.Confirurations;

/// <summary>
/// Setting up a database to store team.
/// </summary>
/// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{T}" />
/// <seealso cref="TeamService.BusinessLogic.Entities.Team" />
public class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.HasKey(team => team.Id);
        builder.Property(team => team.Id).ValueGeneratedOnAdd();

        builder.Property(team => team.Name).IsRequired();

        builder.ToTable("Teams");
    }
}
