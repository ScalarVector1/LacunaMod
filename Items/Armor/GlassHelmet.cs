using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader;

namespace LacunaMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class GlassHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.SetStaticDefaults();
            DisplayName.SetDefault("Fuseglass Helmet");
            Tooltip.SetDefault("5% increased ranged crit chance");
        }

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 2;
			item.defense = 5;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("GlassChestplate") && legs.type == mod.ItemType("GlassLeggings");
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = "Taking damage leaves behind glass shards that damage foes when touched";
            player.GetModPlayer<LCPlr>().glassset = true;
            if (Main.rand.NextFloat() < 0.1578947f)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = Main.LocalPlayer.Center;
                dust = Main.dust[Terraria.Dust.NewDust(player.position, player.width, player.height, 275, 0f, 0.5263162f, 0, new Color(255, 255, 255), 1.381579f)];
                dust.noGravity = true;
                dust.shader = GameShaders.Armor.GetSecondaryShader(54, Main.LocalPlayer);
            }

            //bwew
        }
        public override void UpdateEquip(Player player)
        {
            player.rangedCrit += 5;
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