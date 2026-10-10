using LootFallGame.DataAccess.Sqlite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LootFallGame.DataAccess.Sqlite.Configurations
{
    public class TerrainItemsConfigurations : IEntityTypeConfiguration<TerrainItemsEntity>
    {
        public void Configure(EntityTypeBuilder<TerrainItemsEntity> builder)
        {
            builder.ToTable("terrainsitems");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id)
                .HasMaxLength(36);
            builder.Property(a => a.IdTerrains)
                .IsRequired()
                .HasMaxLength(36);
            builder.Property(a => a.IdItems)
                .IsRequired()
                .HasMaxLength(36);
        }
    }
}
