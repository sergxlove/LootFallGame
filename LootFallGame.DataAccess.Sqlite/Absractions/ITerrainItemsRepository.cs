using LootFallGame.DataAccess.Sqlite.Infrastructure;
using LootFallGame.DataAccess.Sqlite.Models;

namespace LootFallGame.DataAccess.Sqlite.Absractions
{
    public interface ITerrainItemsRepository
    {
        Task<ResOperBd> AddAsync(TerrainItemsEntity terrainItem, CancellationToken token);
        Task<ResOperBd> DeleteAsync(TerrainItemsEntity terrainItem, CancellationToken token);
        Task<IEnumerable<TerrainItemsEntity>> GetAllAsync(CancellationToken token);
        Task<IEnumerable<string>> GetAllItemsIdAsynv(string id, CancellationToken token);
        Task<ResOperBd> UpdateAsync(TerrainItemsEntity terrainItem, CancellationToken token);
    }
}