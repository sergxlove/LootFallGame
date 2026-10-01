using Microsoft.EntityFrameworkCore;

namespace LootFallGame.DataAccess.Sqlite
{
    public class LootFallDbContext : DbContext
    {
        private readonly string _dbKey;
        private readonly string _hmacSecret;

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

    }
}
