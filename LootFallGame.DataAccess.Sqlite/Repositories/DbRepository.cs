using LootFallGame.DataAccess.Sqlite.Absractions;
using LootFallGame.DataAccess.Sqlite.Models;
using System.Text.Json;

namespace LootFallGame.DataAccess.Sqlite.Repositories
{
    public class DbRepository : IDbRepository
    {
        private readonly ItemsRepository _itemsRepository;
        private readonly LocationsRepository _locationsRepository;
        private readonly TerrainsRepository _terrainsRepository;
        private readonly CraftsRepository _craftsRepository;
        private readonly LocationItemsRepository _locationItemsRepository;
        private readonly TerrainItemsRepository _terrainItemsRepository;

        public DbRepository(
            ItemsRepository itemsRepository,
            LocationsRepository locationsRepository,
            TerrainsRepository terrainsRepository,
            CraftsRepository craftsRepository,
            LocationItemsRepository locationItemsRepository,
            TerrainItemsRepository terrainItemsRepository)
        {
            _itemsRepository = itemsRepository;
            _locationsRepository = locationsRepository;
            _terrainsRepository = terrainsRepository;
            _craftsRepository = craftsRepository;
            _locationItemsRepository = locationItemsRepository;
            _terrainItemsRepository = terrainItemsRepository;
        }

        public async Task<bool> ExportToJsonAsync(string filePath, CancellationToken token)
        {
            try
            {
                var data = new ExportData
                {
                    Items = (await _itemsRepository.GetAllAsync(token)).ToList(),
                    Locations = (await _locationsRepository.GetAllAsync(token)).ToList(),
                    Terrains = (await _terrainsRepository.GetAllAsync(token)).ToList(),
                    Crafts = (await _craftsRepository.GetAllAsync(token)).ToList(),
                    LocationItems = (await _locationItemsRepository.GetAllAsync(token)).ToList(),
                    TerrainItems = (await _terrainItemsRepository.GetAllAsync(token)).ToList()
                };

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };

                string json = JsonSerializer.Serialize(data, options);

                string? directory = Path.GetDirectoryName(filePath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                await File.WriteAllTextAsync(filePath, json, token);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> ImportFromJsonAsync(string filePath, CancellationToken token)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    return false;
                }

                string json = await File.ReadAllTextAsync(filePath, token);

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var data = JsonSerializer.Deserialize<ExportData>(json, options);

                if (data is null)
                {
                    return false;
                }

                foreach (var item in data.Items)
                {
                    var result = await _itemsRepository.AddAsync(item, token);
                    if (!result.IsSuccessed)
                    {
                        return false;
                    }
                }

                foreach (var location in data.Locations)
                {
                    var result = await _locationsRepository.AddAsync(location, token);
                    if (!result.IsSuccessed)
                    {
                        return false;
                    }
                }

                foreach (var terrain in data.Terrains)
                {
                    var result = await _terrainsRepository.AddAsync(terrain, token);
                    if (!result.IsSuccessed)
                    {
                        return false;
                    }
                }

                foreach (var craft in data.Crafts)
                {
                    var result = await _craftsRepository.AddAsync(craft, token);
                    if (!result.IsSuccessed)
                    {
                        return false;
                    }
                }

                foreach (var locationItem in data.LocationItems)
                {
                    var result = await _locationItemsRepository.AddAsync(locationItem, token);
                    if (!result.IsSuccessed)
                    {
                        return false;
                    }
                }

                foreach (var terrainItem in data.TerrainItems)
                {
                    var result = await _terrainItemsRepository.AddAsync(terrainItem, token);
                    if (!result.IsSuccessed)
                    {
                        return false;
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    internal class ExportData
    {
        public List<ItemsEntity> Items { get; set; } = [];
        public List<LocationsEntity> Locations { get; set; } = [];
        public List<TerrainsEntity> Terrains { get; set; } = [];
        public List<CraftsEntity> Crafts { get; set; } = [];
        public List<LocationItemsEntity> LocationItems { get; set; } = [];
        public List<TerrainItemsEntity> TerrainItems { get; set; } = [];
    }
}
