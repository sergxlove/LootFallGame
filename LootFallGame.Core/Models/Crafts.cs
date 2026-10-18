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
            var error = Validate(id, idItemResult, quantityItemResult, needItems);
            if (error is not null)
                return new ResModel<Crafts>(error);

            return new ResModel<Crafts>(new Crafts(id, idItemResult, quantityItemResult, needItems));
        }

        private static string? Validate(
            string id,
            string idItemResult,
            int quantityItemResult,
            Dictionary<string, int>? needItems)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(id))
                errors.Add("Craft id must not be empty.");

            if (string.IsNullOrWhiteSpace(idItemResult))
                errors.Add("Result item id must not be empty.");

            if (quantityItemResult <= 0)
                errors.Add("Result item quantity must be greater than zero.");

            if (needItems is null || needItems.Count == 0)
            {
                errors.Add("Craft must require at least one item.");
            }
            else
            {
                foreach (var (itemId, quantity) in needItems)
                {
                    if (string.IsNullOrWhiteSpace(itemId))
                        errors.Add("Required item id must not be empty.");

                    if (quantity <= 0)
                        errors.Add($"Required item '{itemId}' quantity must be greater than zero.");
                }

                if (!string.IsNullOrWhiteSpace(idItemResult) && needItems.ContainsKey(idItemResult))
                    errors.Add("Result item cannot be required as an ingredient for itself.");
            }

            return errors.Count == 0 ? null : string.Join("; ", errors);
        }
    }
}
