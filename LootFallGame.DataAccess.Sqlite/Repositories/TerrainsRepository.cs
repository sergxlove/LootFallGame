using LootFallGame.DataAccess.Sqlite.Absractions;
using LootFallGame.DataAccess.Sqlite.Infrastructure;
using LootFallGame.DataAccess.Sqlite.Models;
using Microsoft.EntityFrameworkCore;

namespace LootFallGame.DataAccess.Sqlite.Repositories
{
    public class TerrainsRepository : ITerrainsRepository
    {
        private readonly LootFallDbContext _context;

        public TerrainsRepository(LootFallDbContext context)
        {
            _context = context;
        }

        public async Task<ResOperBd> AddAsync(TerrainsEntity terrain, CancellationToken token)
        {
            try
            {
                await _context.TerrainsTb
                    .AddAsync(terrain, token);
                await _context.SaveChangesAsync(token);
                return new(true, terrain.Id);
            }
            catch
            {
                return new(false);
            }
        }

        public async Task<IEnumerable<TerrainsEntity>> GetAllAsync(CancellationToken token)
        {
            try
            {
                return await _context.TerrainsTb
                    .AsNoTracking()
                    .ToListAsync(token);
            }
            catch
            {
                return [];
            }
        }

        public async Task<ResOperBd> UpdateAsync(TerrainsEntity terrain, CancellationToken token)
        {
            try
            {
                int result = await _context.TerrainsTb
                    .Where(a => a.Id == terrain.Id)
                    .ExecuteUpdateAsync(a => a
                    .SetProperty(a => a.Name, terrain.Name)
                    .SetProperty(a => a.Description, terrain.Description), token);
                return new(true, result.ToString());
            }
            catch
            {
                return new(false);
            }
        }

        public async Task<ResOperBd> DeleteAsync(TerrainsEntity terrain, CancellationToken token)
        {
            try
            {
                int result = await _context.TerrainsTb
                    .Where(a => a.Id == terrain.Id)
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
