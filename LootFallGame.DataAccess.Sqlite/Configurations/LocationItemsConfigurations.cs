using LootFallGame.DataAccess.Sqlite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LootFallGame.DataAccess.Sqlite.Configurations
{
    public class LocationItemsConfigurations : IEntityTypeConfiguration<LocationItemsEntity>
    {
        public void Configure(EntityTypeBuilder<LocationItemsEntity> builder)
        {
            builder.ToTable("locationsitems");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id)
                .HasMaxLength(36);
            builder.Property(a => a.IdLocations)
                .IsRequired()
                .HasMaxLength(36);
            builder.Property(a => a.IdItems)
                .IsRequired()
                .HasMaxLength(36);
        }
    }
}
