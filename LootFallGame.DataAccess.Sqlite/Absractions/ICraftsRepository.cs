using LootFallGame.DataAccess.Sqlite.Infrastructure;
using LootFallGame.DataAccess.Sqlite.Models;

namespace LootFallGame.DataAccess.Sqlite.Absractions
{
    public interface ICraftsRepository
    {
        Task<ResOperBd> AddAsync(CraftsEntity craft, CancellationToken token);
        Task<ResOperBd> DeleteAsync(CraftsEntity crafts, CancellationToken token);
        Task<IEnumerable<CraftsEntity>> GetAllAsync(CancellationToken token);
        Task<IEnumerable<string>> GetAllOnlyIdAsync(CancellationToken token);
        Task<ResOperBd> UpdateAsync(CraftsEntity craft, CancellationToken token);
    }
}