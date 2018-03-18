using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LacunaMod.Items.Tools
{
    public class FusedPickaxeAxe : QuickTool
    {
        public override void Data()
        {
            name = "Fused Multicutter";
            pow = new Power(ToolType.PickaxeAxe, 80, 80);
            damage = 7;
            useTime = 19;
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
