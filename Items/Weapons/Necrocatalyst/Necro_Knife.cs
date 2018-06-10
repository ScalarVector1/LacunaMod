using LacunaMod.Projectiles.Necro_Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace LacunaMod.Items.Weapons.Necrocatalyst
{
	public class Necro_Knife : ModItem
    { 

                public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Terrible Knives");
        Tooltip.SetDefault("Throws a cone of tormenting knives");
    }

	
		public override void SetDefaults()
		{
			item.shootSpeed = 12f;
			item.damage = 9;
			item.knockBack = 7f;
			item.useStyle = 1;
			item.useAnimation = 25;
			item.useTime = 25;
			item.width = 40;
			item.height = 40;
			item.maxStack = 1;
			item.rare = 3;

			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
            item.melee = true;

            item.UseSound = SoundID.Item1;
			item.shoot = mod.ProjectileType<Necro_Knife_Projectile>();

       
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 2 + Main.rand.Next(2); // 4 or 5 shots
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(25)); // 30 degree spread.
                                                                                                               // If you want to randomize the speed to stagger the projectiles
                float scale = 1f - (Main.rand.NextFloat() * .1f);
                perturbedSpeed = perturbedSpeed * scale;
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false; // return false because we don't want tmodloader to shoot projectile
        }
    }
}
