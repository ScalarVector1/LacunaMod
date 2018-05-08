using Terraria;
using Terraria.ModLoader;

namespace LacunaMod.Items.KeyItems
{

    class Hammer : ModItem
    {


        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Forge Hammer");
            Tooltip.SetDefault("PERMANENTLY Upgrades the lightning smash\n Smash faster and deal 100 damage on impact\n Requires Xel-Val Bolt");
        }

        public override void SetDefaults()
        {
            item.SetSize(26, 40);
            item.noMelee = true;
            item.consumable = true;
            item.value = 1500;
            item.rare = 6;
            item.useStyle = 1;
            item.useTime = 15;
            item.useAnimation = 15;
        }

        public override bool CanUseItem(Player player)
        {
            return player.GetModPlayer<LCPlr>().Hammer == false && player.GetModPlayer<LCPlr>().Bolt == true;
        }

        public override bool UseItem(Player player)
        {
            player.GetModPlayer<LCPlr>().Hammer = true;
            return true;
        }

    }
}