using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace LacunaMod.Items.Tileitems
{
    public class King_Tile_Plate : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Beautifuly designed decorative plates");
            DisplayName.SetDefault("Auriferous Plating");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.createTile = mod.TileType("King_Tile_Plate_Placed");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.SetResult(this);
            recipe.AddIngredient(null, "King_Tile_Plain", 50);
            recipe.AddIngredient(null, "King_Material", 3);
            recipe.AddRecipe();
        }

    }
}