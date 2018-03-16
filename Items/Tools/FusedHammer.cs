using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LacunaMod.Items.Tools
{
    public class FusedHammer : QuickTool
    {
        public override void Data()
        {
            name = "Fuseglass Hammer";
            pow = new Power(ToolType.Hammer, 50);
            damage = 9;
            useTime = 18;
            useAnim = 17;
            value = 151;
            rarity = 2;
            kb = 2.2f;
            size = new int[] { 46, 46 };
        }

        public override void AddRecipes()
        {
            QuickRecipe rec = new QuickRecipe(this,
                new Ingredient[]{
                    new Ingredient(mod.ItemType("FusedFossil"), 5),
                    new Ingredient(mod.ItemType("Fuseglass"), 10)
                },
                TileID.WorkBenches,
            mod);
        }
    }
}
