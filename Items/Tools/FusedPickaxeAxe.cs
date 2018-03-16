using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LacunaMod.Items.Tools
{
    public class FusedPickaxe : QuickTool
    {
        public override void Data()
        {
            name = "Fuseglass Pickaxe Axe";
            pow = new Power(ToolType.PickaxeAxe, 50, 50);
            damage = 7;
            useTime = 18;
            useAnim = 17;
            value = 123;
            rarity = 2;
            kb = 1f;
            size = new int[] { 46, 46 };
        }

        public override void AddRecipes()
        {
            QuickRecipe rec = new QuickRecipe(this,
                new Ingredient[]{
                    new Ingredient(mod.ItemType("FusedFossil"), 6),
                    new Ingredient(mod.ItemType("Fuseglass"), 12)
                },
                TileID.WorkBenches,
            mod);
        }
    }
}
