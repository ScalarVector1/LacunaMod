using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LacunaMod.Items.Weapons.Melee
{
    public class FusedSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fuseglass Saber");
        }

        public override void SetDefaults()
        {
            item.SetSize(46, 46);
            item.melee = true;
            item.damage = 15;
            item.useTime = 18;
            item.useAnimation = 18;
            item.knockBack = 2f;
            item.value = 134;
            item.rare = 2;
            item.autoReuse = true;
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
