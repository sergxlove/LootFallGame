using LootFallGame.DataAccess.Sqlite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LootFallGame.DataAccess.Sqlite.Configurations
{
    public class ItemsConfigurations : IEntityTypeConfiguration<ItemsEntity>
    {
        public void Configure(EntityTypeBuilder<ItemsEntity> builder)
        {
            throw new NotImplementedException();
        }
    }
}
