using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamService.BusinessLogic.Entities;

namespace TeamService.DataAccess.Confirurations;

public class PlayerConfiguration : IEntityTypeConfiguration<Player>
{
    public void Configure(EntityTypeBuilder<Player> builder)
    {
        builder.HasKey(player => player.Id);
        builder.Property(player => player.Id).ValueGeneratedOnAdd();

        builder.Property(player => player.Name).IsRequired();

        builder.ToTable("Players");
    }
}
