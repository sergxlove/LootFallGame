using LootFallGame.DataAccess.Sqlite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LootFallGame.DataAccess.Sqlite.Configurations
{
    public class TerrainItemsConfigurations : IEntityTypeConfiguration<TerrainItemsEntity>
    {
        public void Configure(EntityTypeBuilder<TerrainItemsEntity> builder)
        {
            throw new NotImplementedException();
        }
    }
}
