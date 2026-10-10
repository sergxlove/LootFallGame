using LootFallGame.DataAccess.Sqlite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LootFallGame.DataAccess.Sqlite.Configurations
{
    public class CraftsConfigurations : IEntityTypeConfiguration<CraftsEntity>
    {
        public void Configure(EntityTypeBuilder<CraftsEntity> builder)
        {
            builder.ToTable("crafts");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id)
                .HasMaxLength(36);
            builder.Property(a => a.IdItemResult)
                .IsRequired()
                .HasMaxLength(36);
            builder.Property(a => a.QuantityResult)
                .IsRequired();
            builder.Property(a => a.NeedItem)
                .IsRequired()
                .HasMaxLength(512);
        }
    }
}
