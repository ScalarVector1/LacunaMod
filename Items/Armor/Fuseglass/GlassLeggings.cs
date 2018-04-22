using Terraria;
using Terraria.ModLoader;

namespace LacunaMod.Items.Armor.Fuseglass
{
	[AutoloadEquip(EquipType.Legs)]
	public class GlassLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.SetStaticDefaults();
            DisplayName.SetDefault("Fuseglass Shingles");
            Tooltip.SetDefault("5% increased movement speed\nbad jokes ha HAAA");
        }

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 2;
			item.defense = 6;
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.05f;
		}

        //public override void AddRecipes()
        //{
        //	ModRecipe recipe = new ModRecipe(mod);
        //	recipe.AddIngredient(null, "EquipMaterial", 60);
        //	recipe.AddTile(null, "ExampleWorkbench");
        //	recipe.SetResult(this);
        //	recipe.AddRecipe();
        //}
    }
}