using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamService.BusinessLogic.Entities;

namespace TeamService.DataAccess.Confirurations;

public class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.HasKey(team => team.Id);
        builder.Property(team => team.Id).ValueGeneratedOnAdd();

        builder.Property(team => team.Name).IsRequired();

        builder.ToTable("Teams");
    }
}
