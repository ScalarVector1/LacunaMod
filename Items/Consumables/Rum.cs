using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LacunaMod.Items.Consumables
{
    public class Rum : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ella's Rum");
            Tooltip.SetDefault("''Well I want to get drunk so im not sharing''");
        }

        public override void SetDefaults()
        {
            item.SetSize(20, 28);
            item.noMelee = true;
            item.consumable = true;
            item.healMana = 550;
            item.value = 1500;
            item.rare = 9;
            item.useStyle = 4;
            item.useTime = 45;
            item.useAnimation = 45;
        }


    }
}
