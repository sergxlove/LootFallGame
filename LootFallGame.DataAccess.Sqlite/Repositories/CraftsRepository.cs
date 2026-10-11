using LootFallGame.DataAccess.Sqlite.Absractions;
using LootFallGame.DataAccess.Sqlite.Infrastructure;
using LootFallGame.DataAccess.Sqlite.Models;
using Microsoft.EntityFrameworkCore;

namespace LootFallGame.DataAccess.Sqlite.Repositories
{
    public class CraftsRepository : ICraftsRepository
    {
        private readonly LootFallDbContext _context;

        public CraftsRepository(LootFallDbContext context)
        {
            _context = context;
        }

        public async Task<ResOperBd> AddAsync(CraftsEntity craft, CancellationToken token)
        {
            try
            {
                await _context.CraftsTb
                    .AddAsync(craft, token);
                await _context.SaveChangesAsync(token);
                return new(true, craft.Id);
            }
            catch
            {
                return new(false);
            }
        }

        public async Task<IEnumerable<CraftsEntity>> GetAllAsync(CancellationToken token)
        {
            try
            {
                return await _context.CraftsTb
                    .AsNoTracking()
                    .ToListAsync(token);
            }
            catch
            {
                return [];
            }
        }

        public async Task<IEnumerable<string>> GetAllOnlyIdAsync(CancellationToken token)
        {
            try
            {
                return await _context.CraftsTb
                    .AsNoTracking()
                    .Select(a => a.Id)
                    .ToListAsync(token);
            }
            catch
            {
                return [];
            }
        }

        public async Task<ResOperBd> UpdateAsync(CraftsEntity craft, CancellationToken token)
        {
            try
            {
                int result = await _context.CraftsTb
                    .Where(a => a.Id == craft.Id)
                    .ExecuteUpdateAsync(a => a
                    .SetProperty(a => a.IdItemResult, craft.IdItemResult)
                    .SetProperty(a => a.NeedItem, craft.NeedItem)
                    .SetProperty(a => a.QuantityResult, craft.QuantityResult), token);
                return new(true, result.ToString());
            }
            catch
            {
                return new(false);
            }
        }

        public async Task<ResOperBd> DeleteAsync(CraftsEntity crafts, CancellationToken token)
        {
            try
            {
                int result = await _context.CraftsTb
                    .Where(a => a.Id == crafts.Id)
                    .ExecuteDeleteAsync(token);
                return new(true, result.ToString());
            }
            catch
            {
                return new(false);
            }
        }
    }
}
