using LootFallGame.DataAccess.Sqlite.Infrastructure;
using LootFallGame.DataAccess.Sqlite.Models;

namespace LootFallGame.DataAccess.Sqlite.Absractions
{
    public interface ILocationsRepository
    {
        Task<ResOperBd> AddAsync(LocationsEntity location, CancellationToken token);
        Task<ResOperBd> DeleteAsync(LocationsEntity location, CancellationToken token);
        Task<IEnumerable<LocationsEntity>> GetAllAsync(CancellationToken token);
        Task<ResOperBd> UpdateAsync(LocationsEntity location, CancellationToken token);
    }
}