namespace LootFallGame.DataAccess.Sqlite.Absractions
{
    public interface IDbRepository
    {
        Task<bool> ExportToJsonAsync(string filePath, CancellationToken token);
        Task<bool> ImportFromJsonAsync(string filePath, CancellationToken token);
    }
}