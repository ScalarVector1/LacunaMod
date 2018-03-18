using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LacunaMod.Items.Accessories
{
    public class GlassShell : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Glass Shell");
            Tooltip.SetDefault("+15% damage dealt / received above 1/4 health" +
                "\n20% less damage dealt & 15% less received below 1/4 health");
        }

        public override void SetDefaults()
        {
            item.noMelee = true;
            item.width = 46;
            item.height = 38;
            item.value = 1200;
            item.rare = 2;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<LCPlr>().glassshell = true;
        }
    }
}
