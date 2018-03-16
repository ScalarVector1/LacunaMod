using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LacunaMod
{
    public class Ingredient
    {
        public int item;
        public int count;

        public Ingredient(int item, int count = 1)
        {
            this.item = item;
            this.count = count;
        }
    }

    public class QuickRecipe
    {
        public ModItem result;
        public Ingredient[] ingredients;
        public int tile;
        public Mod mod;

        public QuickRecipe(ModItem result, Ingredient[] ingredients, int tile, Mod mod)
        {
            this.result = result;
            this.ingredients = ingredients;
            this.tile = tile;
            this.mod = mod;
            AddRecipe();
        }

        void AddRecipe()
        {
            ModRecipe recipe = new ModRecipe(mod);
            foreach (Ingredient ing in ingredients)
            {
                recipe.AddIngredient(ing.item, ing.count);
            }
            if (tile != 0)
            {
                recipe.AddTile(tile);
            }
            recipe.SetResult(result);
            recipe.AddRecipe();
        }
    }
}
