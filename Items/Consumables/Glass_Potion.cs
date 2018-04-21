using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LacunaMod.Items.Consumables
{
    public class Glass_Potion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Retribution Potion");
        }

        public override void SetDefaults()
        {
            item.SetSize(20, 28);
            item.noMelee = true;
            item.consumable = true;
            item.potion = true;
            item.healLife = 50;
            item.buffType = mod.BuffType<Buffs.Buff_Retribution>();
            item.buffTime = 10;
            item.value = 1500;
            item.rare = 3;
            item.useStyle = 4;
            item.useTime = 5;
            item.useAnimation = 5;
        }

        public override void AddRecipes()
        {
            QuickRecipe rec = new QuickRecipe(this,
                new Ingredient[]
                {
                    new Ingredient(mod.ItemType("Glass_Bottle")),
                    new Ingredient(ItemID.HealingPotion),
                    new Ingredient(mod.ItemType("Lacuna_Material"), 5)
                },
                TileID.Bottles,
                mod);
        }
    }
}
