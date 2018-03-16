using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LacunaMod.Items.Tools
{
    public class FusedSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fuseglass Sword");
        }

        public override void SetDefaults()
        {
            size = new int[] { 46, 46 };
            item.melee = true;
            item.damage = 13;
            item.useTime = 22;
            item.useAnimation = 22;
            item.knockBack = 2f;
            item.value = 134;
            item.rare = 2;
        }

        public override void AddRecipes()
        {
            QuickRecipe rec = new QuickRecipe(this,
                new Ingredient[]{
                    new Ingredient(mod.ItemType("Fuseglass"), 10)
                },
                TileID.WorkBenches,
            mod);
        }
    }
}
