using LootFallGame.DataAccess.Sqlite.Infrastructure;
using LootFallGame.DataAccess.Sqlite.Models;

namespace LootFallGame.DataAccess.Sqlite.Absractions
{
    public interface ILocationItemsRepository
    {
        Task<ResOperBd> AddAsync(LocationItemsEntity locationItem, CancellationToken token);
        Task<ResOperBd> DeleteAsync(LocationItemsEntity locationItem, CancellationToken token);
        Task<IEnumerable<LocationItemsEntity>> GetAllAsync(CancellationToken token);
        Task<IEnumerable<string>> GetAllItemsIdAsynv(string id, CancellationToken token);
        Task<ResOperBd> UpdateAsync(LocationItemsEntity locationItem, CancellationToken token);
    }
}