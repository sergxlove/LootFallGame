namespace LootFallGame.DataAccess.Sqlite.Infrastructure
{
    public class ResOperBd
    {
        public bool IsSuccessed { get; set; }
        public string Comment { get; set; } = string.Empty;

        public ResOperBd()
        {
            
        }

        public ResOperBd(bool isSuccessed)
        {
            IsSuccessed = isSuccessed;
        }

        public ResOperBd(bool isSuccessed, string comment)
        {
            IsSuccessed = isSuccessed;
            Comment = comment;
        }
    }
}
