using LootFallGame.DataAccess.Sqlite.Absractions;
using LootFallGame.DataAccess.Sqlite.Infrastructure;
using LootFallGame.DataAccess.Sqlite.Models;
using Microsoft.EntityFrameworkCore;

namespace LootFallGame.DataAccess.Sqlite.Repositories
{
    public class LocationItemsRepository : ILocationItemsRepository
    {
        private readonly LootFallDbContext _context;

        public LocationItemsRepository(LootFallDbContext context)
        {
            _context = context;
        }

        public async Task<ResOperBd> AddAsync(LocationItemsEntity locationItem, CancellationToken token)
        {
            try
            {
                await _context.LocationItemsTb
                    .AddAsync(locationItem, token);
                await _context.SaveChangesAsync(token);
                return new(true, locationItem.Id);
            }
            catch
            {
                return new(false);
            }
        }

        public async Task<IEnumerable<LocationItemsEntity>> GetAllAsync(CancellationToken token)
        {
            try
            {
                return await _context.LocationItemsTb
                    .AsNoTracking()
                    .ToListAsync(token);
            }
            catch
            {
                return [];
            }
        }

        public async Task<IEnumerable<string>> GetAllItemsIdAsynv(string id, CancellationToken token)
        {
            try
            {
                return await _context.LocationItemsTb
                    .AsNoTracking()
                    .Select(a => a.IdItems)
                    .ToListAsync(token);
            }
            catch
            {
                return [];
            }
        }

        public async Task<ResOperBd> UpdateAsync(LocationItemsEntity locationItem, CancellationToken token)
        {
            try
            {
                int result = await _context.LocationItemsTb
                    .Where(a => a.Id == locationItem.Id)
                    .ExecuteUpdateAsync(a => a
                    .SetProperty(a => a.IdLocations, locationItem.IdLocations)
                    .SetProperty(a => a.IdItems, locationItem.IdItems), token);
                return new(true, result.ToString());
            }
            catch
            {
                return new(false);
            }
        }

        public async Task<ResOperBd> DeleteAsync(LocationItemsEntity locationItem, CancellationToken token)
        {
            try
            {
                int result = await _context.LocationItemsTb
                    .Where(a => a.Id == locationItem.Id)
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
