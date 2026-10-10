namespace LootFallGame.DataAccess.Sqlite.Models
{
    public class CraftsEntity
    {
        public string Id { get; set; } = string.Empty;
        public string IdItemResult { get; set; } = string.Empty;
        public int QuantityResult { get; set; }
        public string NeedItem { get; set; } = string.Empty;
    }
}
