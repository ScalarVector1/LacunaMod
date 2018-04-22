using Terraria;
using Terraria.ModLoader;

namespace LacunaMod.Items.Armor.Fuseglass
{
    [AutoloadEquip(EquipType.Body)]
    public class GlassChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Fuseglass Chestplate");
            Tooltip.SetDefault("+5% chance not to consume ammo");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 10000;
            item.rare = 2;
            item.defense = 7;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<LCPlr>().glasschest = true;
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