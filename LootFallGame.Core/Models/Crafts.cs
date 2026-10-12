using LootFallGame.Core.Infrastructure;

namespace LootFallGame.Core.Models
{
    public class Crafts
    {
        public string Id { get; } = string.Empty;
        public string IdItemResult { get; } = string.Empty;
        public int QuantityItemResult { get; } = 0;
        public Dictionary<string, int> NeedItems { get; } = [];

        private Crafts(string id, string idItemResult, int quantityItemResult, 
            Dictionary<string, int> needItems)
        {
            Id = id;
            IdItemResult = idItemResult;
            QuantityItemResult = quantityItemResult;
            NeedItems = needItems;
        }

        public static ResModel<Crafts> Create(string id, string idItemResult, int quantityItemResult,
            Dictionary<string, int> needItems)
        {

            return new ResModel<Crafts>(new Crafts(id, idItemResult, quantityItemResult, needItems));
        }
    }
}
