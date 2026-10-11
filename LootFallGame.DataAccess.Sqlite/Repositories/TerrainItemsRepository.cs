using LootFallGame.DataAccess.Sqlite.Absractions;
using LootFallGame.DataAccess.Sqlite.Infrastructure;
using LootFallGame.DataAccess.Sqlite.Models;
using Microsoft.EntityFrameworkCore;

namespace LootFallGame.DataAccess.Sqlite.Repositories
{
    public class TerrainItemsRepository : ITerrainItemsRepository
    {
        private readonly LootFallDbContext _context;

        public TerrainItemsRepository(LootFallDbContext context)
        {
            _context = context;
        }

        public async Task<ResOperBd> AddAsync(TerrainItemsEntity terrainItem, CancellationToken token)
        {
            try
            {
                await _context.TerrainItemsTb
                    .AddAsync(terrainItem, token);
                await _context.SaveChangesAsync(token);
                return new(true, terrainItem.Id);
            }
            catch
            {
                return new(false);
            }
        }

        public async Task<IEnumerable<TerrainItemsEntity>> GetAllAsync(CancellationToken token)
        {
            try
            {
                return await _context.TerrainItemsTb
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
                return await _context.TerrainItemsTb
                    .AsNoTracking()
                    .Select(a => a.IdItems)
                    .ToListAsync(token);
            }
            catch
            {
                return [];
            }
        }

        public async Task<ResOperBd> UpdateAsync(TerrainItemsEntity terrainItem, CancellationToken token)
        {
            try
            {
                int result = await _context.TerrainItemsTb
                    .Where(a => a.Id == terrainItem.Id)
                    .ExecuteUpdateAsync(a => a
                    .SetProperty(a => a.IdTerrains, terrainItem.IdTerrains)
                    .SetProperty(a => a.IdItems, terrainItem.IdItems), token);
                return new(true, result.ToString());
            }
            catch
            {
                return new(false);
            }
        }

        public async Task<ResOperBd> DeleteAsync(TerrainItemsEntity terrainItem, CancellationToken token)
        {
            try
            {
                int result = await _context.TerrainItemsTb
                    .Where(a => a.Id == terrainItem.Id)
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
