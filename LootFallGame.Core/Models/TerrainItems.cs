using LootFallGame.Core.Infrastructure;

namespace LootFallGame.Core.Models
{
    public class TerrainItems
    {
        public string Id { get; } = string.Empty;
        public string IdTerrains { get; } = string.Empty;
        public string IdItems { get; } = string.Empty;

        private TerrainItems(string id, string idTerrains, string idItems)
        {
            Id = id;
            IdTerrains = idTerrains;
            IdItems = idItems;
        }

        public static ResModel<TerrainItems> Create(string id, string idTerrains, string idItems)
        {
            var error = Validate(id, idTerrains, idItems);
            if (error is not null)
                return new ResModel<TerrainItems>(error);

            return new ResModel<TerrainItems>(new TerrainItems(id, idTerrains, idItems));
        }

        private static string? Validate(string id, string idTerrains, string idItems)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(id))
                errors.Add("Terrain item id must not be empty.");

            if (string.IsNullOrWhiteSpace(idTerrains))
                errors.Add("Terrain id must not be empty.");

            if (string.IsNullOrWhiteSpace(idItems))
                errors.Add("Item id must not be empty.");

            return errors.Count == 0 ? null : string.Join("; ", errors);
        }
    }
}
