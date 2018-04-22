using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LacunaMod.Items.Weapons.Fuseglass
{
	public class Glass_Sword : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Fuseglass Saber");
            Tooltip.SetDefault("Shards splinter off on hits");
		}

		public override void SetDefaults()
		{
			item.damage = 15;
			item.melee = true;
			item.width = 46;
			item.height = 46;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 1;
			item.knockBack = 2;
			item.value = Item.buyPrice(silver: 5);
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            int numberProjectiles = 2 + Main.rand.Next(2);
			{
				Vector2 perturbedSpeed = new Vector2(player.direction, Main.rand.Next(2,3)).RotatedByRandom(MathHelper.ToRadians(90));
				Projectile.NewProjectile(player.position.X, player.position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("GlassShard"), 5, 5, player.whoAmI);
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
