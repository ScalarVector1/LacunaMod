using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LacunaMod.Items.Weapons.Necrocatalyst
{
	public class Necro_Sword : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Twisted Grandsword");
            Tooltip.SetDefault("Beautifully twisted to draw blood");
		}

		public override void SetDefaults()
		{
			item.damage = 32;
			item.melee = true;
			item.width = 54;
			item.height = 54;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = Item.buyPrice(silver: 5);
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(1) == 0)
            {
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("Necro_Dust"));
            }
        }

        //public override void AddRecipes()
        //{
        //ModRecipe recipe = new ModRecipe(mod);
        //recipe.AddIngredient(null, "ExampleItem", 10);
        //recipe.AddTile(null, "ExampleWorkbench");
        //recipe.SetResult(this);
        //recipe.AddRecipe();
        //}
    }
}
