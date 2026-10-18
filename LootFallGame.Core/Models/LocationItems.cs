using LootFallGame.Core.Infrastructure;

namespace LootFallGame.Core.Models
{
    internal class LocationItems
    {
        public string Id { get; } = string.Empty;
        public string IdLocations { get; } = string.Empty;
        public string IdItems { get; } = string.Empty;

        private LocationItems(string id, string idLocations, string idItems)
        {
            Id = id;
            IdLocations = idLocations;
            IdItems = idItems;
        }

        public static ResModel<LocationItems> Create(string id, string idLocations, string idItems)
        {
            var error = Validate(id, idLocations, idItems);
            if (error is not null)
                return new ResModel<LocationItems>(error);

            return new ResModel<LocationItems>(new LocationItems(id, idLocations, idItems));
        }

        private static string? Validate(string id, string idLocations, string idItems)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(id))
                errors.Add("Location item id must not be empty.");

            if (string.IsNullOrWhiteSpace(idLocations))
                errors.Add("Location id must not be empty.");

            if (string.IsNullOrWhiteSpace(idItems))
                errors.Add("Item id must not be empty.");

            return errors.Count == 0 ? null : string.Join("; ", errors);
        }
    }
}
