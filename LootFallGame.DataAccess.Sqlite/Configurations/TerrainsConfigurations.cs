using LootFallGame.DataAccess.Sqlite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LootFallGame.DataAccess.Sqlite.Configurations
{
    public class TerrainsConfigurations : IEntityTypeConfiguration<TerrainsEntity>
    {
        public void Configure(EntityTypeBuilder<TerrainsEntity> builder)
        {
            throw new NotImplementedException();
        }
    }
}
