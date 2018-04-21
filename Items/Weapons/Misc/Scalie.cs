using LacunaMod.Projectiles.Misc;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace LacunaMod.Items.Weapons.Misc
{
	public class Scalie : ModItem
    { 

                public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Scalie's Lightning");
        Tooltip.SetDefault("No curses attached");
    }


        public override void SetDefaults()
        {
            item.shootSpeed = 14f;
            item.damage = 800;
            item.knockBack = 0.5f;
            item.useStyle = 5;
            item.useAnimation = 21;
            item.useTime = 1;
            item.width = 40;
            item.height = 40;
            item.maxStack = 1;
            item.rare = 13;

            item.noUseGraphic = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.melee = true;

            item.UseSound = SoundID.Item72;
            item.shoot = mod.ProjectileType<Greem>();
        }

             public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 4 + Main.rand.Next(0); // 4 or 5 shots
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(2)); // 30 degree spread.
                                                                                                                 // If you want to randomize the speed to stagger the projectiles
                                                                                                                 // float scale = 1f - (Main.rand.NextFloat() * .3f);
                                                                                                                 // perturbedSpeed = perturbedSpeed * scale; 
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false; // return false because we don't want tmodloader to shoot projectile
        }

    }
    
}
