using LootFallGame.DataAccess.Sqlite.Absractions;
using LootFallGame.DataAccess.Sqlite.Dto;
using LootFallGame.DataAccess.Sqlite.Infrastructure;
using LootFallGame.DataAccess.Sqlite.Models;
using Microsoft.EntityFrameworkCore;

namespace LootFallGame.DataAccess.Sqlite.Repositories
{
    public class ItemsRepository : IItemsRepository
    {
        private readonly LootFallDbContext _context;

        public ItemsRepository(LootFallDbContext context)
        {
            _context = context;
        }

        public async Task<ResOperBd> AddAsync(ItemsEntity item, CancellationToken token)
        {
            try
            {
                await _context.ItemsTb
                    .AddAsync(item, token);
                await _context.SaveChangesAsync(token);
                return new(true, item.Id);
            }
            catch
            {
                return new(false);
            }
        }

        public async Task<IEnumerable<ItemsEntity>> GetAllAsync(CancellationToken token)
        {
            try
            {
                return await _context.ItemsTb
                    .AsNoTracking()
                    .ToListAsync(token);
            }
            catch
            {
                return [];
            }
        }

        public async Task<IEnumerable<ShortItems>> GetAllShortAsync(CancellationToken token)
        {
            try
            {
                return await _context.ItemsTb
                    .AsNoTracking()
                    .Select(a => new ShortItems { Id = a.Id, Name = a.Name })
                    .ToListAsync(token);
            }
            catch
            {
                return [];
            }
        }

        public async Task<ResOperBd> UpdateAsync(ItemsEntity item, CancellationToken token)
        {
            try
            {
                int result = await _context.ItemsTb
                    .Where(a => a.Id == item.Id)
                    .ExecuteUpdateAsync(a => a
                    .SetProperty(a => a.Name, item.Name)
                    .SetProperty(a => a.Weight, item.Weight)
                    .SetProperty(a => a.Description, item.Description)
                    .SetProperty(a => a.Stats, item.Stats), token);
                return new(true, result.ToString());
            }
            catch
            {
                return new(false);
            }
        }

        public async Task<ResOperBd> DeleteAsync(ItemsEntity item, CancellationToken token)
        {
            try
            {
                int result = await _context.ItemsTb
                    .Where(a => a.Id == item.Id)
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
