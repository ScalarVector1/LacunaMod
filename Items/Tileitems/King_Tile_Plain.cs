using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace LTEST.Items
{
    public class King_Tile_Plain : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Eerily clean white bricks");
            DisplayName.SetDefault("Castlerock Bricks");
        }

        public override void SetDefaults()
        {
            item.width = 12;
            item.height = 12;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = false;
            item.createTile = mod.TileType("King_Tile_Plain_Placed");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.SetResult(this);
            recipe.AddIngredient(ItemID.GrayBrick, 50);
            recipe.AddIngredient(null, "King_Material", 1);
            recipe.AddRecipe();
        }

    }
}