using LootFallGame.DataAccess.Sqlite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LootFallGame.DataAccess.Sqlite.Configurations
{
    public class TerrainsConfigurations : IEntityTypeConfiguration<TerrainsEntity>
    {
        public void Configure(EntityTypeBuilder<TerrainsEntity> builder)
        {
            builder.ToTable("terrains");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id)
                .HasMaxLength(36);
            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(72);
            builder.Property(a => a.Description)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
