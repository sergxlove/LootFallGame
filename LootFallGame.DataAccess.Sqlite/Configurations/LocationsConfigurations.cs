using LootFallGame.DataAccess.Sqlite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LootFallGame.DataAccess.Sqlite.Configurations
{
    public class LocationsConfigurations : IEntityTypeConfiguration<LocationsEntity>
    {
        public void Configure(EntityTypeBuilder<LocationsEntity> builder)
        {
            throw new NotImplementedException();
        }
    }
}
