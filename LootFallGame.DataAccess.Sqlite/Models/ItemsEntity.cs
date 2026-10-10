namespace LootFallGame.DataAccess.Sqlite.Models
{
    public class ItemsEntity
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public float Weight { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Stats {  get; set; } = string.Empty;
    }
}
