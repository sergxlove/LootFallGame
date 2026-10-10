namespace LootFallGame.DataAccess.Sqlite.Repositories
{
    public class CraftsRepository
    {
        private readonly LootFallDbContext _context;

        public CraftsRepository(LootFallDbContext context)
        {
            _context = context;
        }


    }
}
