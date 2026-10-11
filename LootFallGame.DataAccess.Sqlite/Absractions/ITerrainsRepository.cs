using LootFallGame.DataAccess.Sqlite.Infrastructure;
using LootFallGame.DataAccess.Sqlite.Models;

namespace LootFallGame.DataAccess.Sqlite.Absractions
{
    public interface ITerrainsRepository
    {
        Task<ResOperBd> AddAsync(TerrainsEntity terrain, CancellationToken token);
        Task<ResOperBd> DeleteAsync(TerrainsEntity terrain, CancellationToken token);
        Task<IEnumerable<TerrainsEntity>> GetAllAsync(CancellationToken token);
        Task<ResOperBd> UpdateAsync(TerrainsEntity terrain, CancellationToken token);
    }
}