using LootFallGame.Core.Infrastructure;

namespace LootFallGame.Core.Models
{
    public class Items
    {
        public string Id { get; } = string.Empty;
        public string Name { get; } = string.Empty;
        public float Weight { get; }
        public string Description { get; } = string.Empty;
        public Dictionary<string, int> Stats { get; } = [];

        private Items(string id, string name, float weight, string description,
            Dictionary<string, int> stats)
        {
            Id = id;
            Name = name;
            Weight = weight;
            Description = description;
            Stats = stats;
        }

        public static ResModel<Items> Create(string id, string name, float weight, string description,
            Dictionary<string, int> stats)
        {
            var error = Validate(id, name, weight, description, stats);
            if (error is not null)
                return new ResModel<Items>(error);

            return new ResModel<Items>(new Items(id, name, weight, description, stats));
        }

        private static string? Validate(
            string id,
            string name,
            float weight,
            string description,
            Dictionary<string, int>? stats)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(id))
                errors.Add("Item id must not be empty.");

            if (string.IsNullOrWhiteSpace(name))
                errors.Add("Item name must not be empty.");

            if (weight < 0)
                errors.Add("Item weight must not be negative.");

            if (float.IsNaN(weight) || float.IsInfinity(weight))
                errors.Add("Item weight must be a finite number.");

            if (description is null)
                errors.Add("Item description must not be null.");

            if (stats is null)
            {
                errors.Add("Item stats must not be null.");
            }
            else
            {
                foreach (var (statKey, value) in stats)
                {
                    if (string.IsNullOrWhiteSpace(statKey))
                        errors.Add("Stat key must not be empty.");

                    if (value <= 0)
                        errors.Add($"Stat '{statKey}' value must be greater than zero.");
                }
            }

            return errors.Count == 0 ? null : string.Join("; ", errors);
        }
    }
}
