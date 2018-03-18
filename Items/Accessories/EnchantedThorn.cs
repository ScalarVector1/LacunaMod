using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LacunaMod.Items.Accessories
{
    public class EnchantedThorn : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Enchanted Thorn");
            Tooltip.SetDefault("Adds poison to all ranged weapons");
        }

        public override void SetDefaults()
        {
            item.noMelee = true;
            item.width = 22;
            item.height = 30;
            item.value = 1200;
            item.rare = 2;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<LCPlr>().enchantedthorn = true;
        }
    }
}
