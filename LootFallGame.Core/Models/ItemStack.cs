namespace LootFallGame.Core.Models
{
    public class ItemStack
    {
        public ItemDefinition Def;
        public int Count;
        public float TotalWeight => Def.Weight * Count;
    }
}
