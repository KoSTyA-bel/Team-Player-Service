using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamService.BusinessLogic.Entities;

namespace TeamService.DataAccess.Confirurations;

/// <summary>
/// Setting up a database to store player.
/// </summary>
/// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{T}" />
/// <seealso cref="TeamService.BusinessLogic.Entities.Player" />
public class PlayerConfiguration : IEntityTypeConfiguration<Player>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<Player> builder)
    {
        builder.HasKey(player => player.Id);
        builder.Property(player => player.Id).ValueGeneratedOnAdd();

        builder.Property(player => player.Name).IsRequired();

        builder.ToTable("Players");
    }
}
