using LootFallGame.Core.Enums;

namespace LootFallGame.Core.Models
{
    public class ItemDefinition
    {
        public string Id;              
        public string Name;
        public ItemType Type;
        public float Weight;            
        public Dictionary<string, float> Stats;
    }
}
