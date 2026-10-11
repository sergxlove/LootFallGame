using LootFallGame.DataAccess.Sqlite.Dto;
using LootFallGame.DataAccess.Sqlite.Infrastructure;
using LootFallGame.DataAccess.Sqlite.Models;

namespace LootFallGame.DataAccess.Sqlite.Absractions
{
    public interface IItemsRepository
    {
        Task<ResOperBd> AddAsync(ItemsEntity item, CancellationToken token);
        Task<ResOperBd> DeleteAsync(ItemsEntity item, CancellationToken token);
        Task<IEnumerable<ItemsEntity>> GetAllAsync(CancellationToken token);
        Task<IEnumerable<ShortItems>> GetAllShortAsync(CancellationToken token);
        Task<ResOperBd> UpdateAsync(ItemsEntity item, CancellationToken token);
    }
}