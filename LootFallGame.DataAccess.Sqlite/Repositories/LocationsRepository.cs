using LootFallGame.DataAccess.Sqlite.Absractions;
using LootFallGame.DataAccess.Sqlite.Infrastructure;
using LootFallGame.DataAccess.Sqlite.Models;
using Microsoft.EntityFrameworkCore;

namespace LootFallGame.DataAccess.Sqlite.Repositories
{
    public class LocationsRepository : ILocationsRepository
    {
        private readonly LootFallDbContext _context;

        public LocationsRepository(LootFallDbContext context)
        {
            _context = context;
        }

        public async Task<ResOperBd> AddAsync(LocationsEntity location, CancellationToken token)
        {
            try
            {
                await _context.LocationsTb
                    .AddAsync(location, token);
                await _context.SaveChangesAsync(token);
                return new(true, location.Id);
            }
            catch
            {
                return new(false);
            }
        }

        public async Task<IEnumerable<LocationsEntity>> GetAllAsync(CancellationToken token)
        {
            try
            {
                return await _context.LocationsTb
                    .AsNoTracking()
                    .ToListAsync(token);
            }
            catch
            {
                return [];
            }
        }

        public async Task<ResOperBd> UpdateAsync(LocationsEntity location, CancellationToken token)
        {
            try
            {
                int result = await _context.LocationsTb
                    .Where(a => a.Id == location.Id)
                    .ExecuteUpdateAsync(a => a
                    .SetProperty(a => a.Name, location.Name)
                    .SetProperty(a => a.Description, location.Description), token);
                return new(true, result.ToString());
            }
            catch
            {
                return new(false);
            }
        }

        public async Task<ResOperBd> DeleteAsync(LocationsEntity location, CancellationToken token)
        {
            try
            {
                int result = await _context.LocationsTb
                    .Where(a => a.Id == location.Id)
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
