using LootFallGame.DataAccess.Sqlite.Configurations;
using LootFallGame.DataAccess.Sqlite.Models;
using Microsoft.EntityFrameworkCore;

namespace LootFallGame.DataAccess.Sqlite
{
    public class LootFallDbContext : DbContext
    {
        private readonly string _dbKey;
        private readonly string _hmacSecret;

        public DbSet<CraftsEntity> CraftsTb { get; set; }
        public DbSet<ItemsEntity> ItemsTb { get; set; }
        public DbSet<LocationItemsEntity> LocationItemsTb { get; set; }
        public DbSet<LocationsEntity> LocationsTb { get; set; }
        public DbSet<TerrainItemsEntity> TerrainItemsTb { get; set; }
        public DbSet<TerrainsEntity> TerrainsTb { get; set; }

        static LootFallDbContext()
        {
            SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlcipher());
            SQLitePCL.raw.FreezeProvider();
            SQLitePCL.Batteries_V2.Init();
        }

        public LootFallDbContext(string dbKey, string hmacSecret)
        {
            _dbKey = dbKey;
            _hmacSecret = hmacSecret;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var csb = new Microsoft.Data.Sqlite.SqliteConnectionStringBuilder
            {
                DataSource = "game.db",
                Password = _dbKey,
                Mode = Microsoft.Data.Sqlite.SqliteOpenMode.ReadWriteCreate
            };

            options.UseSqlite(csb.ToString());
            SQLitePCL.Batteries_V2.Init();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CraftsConfigurations());
            modelBuilder.ApplyConfiguration(new ItemsConfigurations());
            modelBuilder.ApplyConfiguration(new LocationItemsConfigurations());
            modelBuilder.ApplyConfiguration(new LocationsConfigurations());
            modelBuilder.ApplyConfiguration(new TerrainItemsConfigurations());
            modelBuilder.ApplyConfiguration(new TerrainsConfigurations());
            base.OnModelCreating(modelBuilder);
        }

    }
}
