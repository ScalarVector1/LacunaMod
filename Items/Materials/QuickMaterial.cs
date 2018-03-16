using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LacunaMod.Items.Materials
{
    public abstract class QuickMaterial : ModItem
    {
        public string name;
        public string tooltip;
        public int[] size = new int[] { 32, 32 };
        public int rarity = 0;
        public int value = 0;

        public abstract void Data();

        public override void SetStaticDefaults()
        {
            Data();
            DisplayName.SetDefault(name);
            Tooltip.SetDefault(tooltip);
        }

        public override void SetDefaults()
        {
            item.SetSize(size);
            item.rare = rarity;
            item.value = value;
        }
    }
}
