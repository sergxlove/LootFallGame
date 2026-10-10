using LootFallGame.DataAccess.Sqlite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LootFallGame.DataAccess.Sqlite.Configurations
{
    public class LocationItemsConfigurations : IEntityTypeConfiguration<LocationItemsEntity>
    {
        public void Configure(EntityTypeBuilder<LocationItemsEntity> builder)
        {
            throw new NotImplementedException();
        }
    }
}
