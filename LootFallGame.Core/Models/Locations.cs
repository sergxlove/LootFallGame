using LootFallGame.Core.Infrastructure;

namespace LootFallGame.Core.Models
{
    public class Locations
    {
        public string Id { get; } = string.Empty;
        public string Name { get; } = string.Empty;
        public string Description { get; } = string.Empty;

        private Locations(string id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public static ResModel<Locations> Create(string id, string name, string description)
        {
            var error = Validate(id, name, description);
            if (error is not null)
                return new ResModel<Locations>(error);

            return new ResModel<Locations>(new Locations(id, name, description));
        }

        private static string? Validate(string id, string name, string description)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(id))
                errors.Add("Location id must not be empty.");

            if (string.IsNullOrWhiteSpace(name))
                errors.Add("Location name must not be empty.");

            if (description is null)
                errors.Add("Location description must not be null.");

            return errors.Count == 0 ? null : string.Join("; ", errors);
        }
    }
}
