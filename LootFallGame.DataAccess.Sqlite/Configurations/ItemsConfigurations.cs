using LootFallGame.DataAccess.Sqlite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LootFallGame.DataAccess.Sqlite.Configurations
{
    public class ItemsConfigurations : IEntityTypeConfiguration<ItemsEntity>
    {
        public void Configure(EntityTypeBuilder<ItemsEntity> builder)
        {
            builder.ToTable("items");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id)
                .HasMaxLength(36);
            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(72);
            builder.Property(a => a.Description)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(a => a.Weight)
                .IsRequired();
            builder.Property(a => a.Stats)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
