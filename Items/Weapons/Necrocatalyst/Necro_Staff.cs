using LacunaMod.Projectiles.Necro_Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace LacunaMod.Items.Weapons.Necrocatalyst
{
	public class Necro_Staff : ModItem
    { 

                public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("The Blue Torch");
        Tooltip.SetDefault("Lighting the way to darkness");
    }

	
		public override void SetDefaults()
		{
			item.shootSpeed = 8f;
			item.damage = 14;
			item.knockBack = 3f;
			item.useStyle = 1;
			item.useAnimation = 35;
			item.useTime = 35;
			item.width = 40;
			item.height = 40;
			item.maxStack = 1;
			item.rare = 3;
            item.mana = 35;

			item.noUseGraphic = false;
			item.noMelee = true;
			item.autoReuse = false;
            item.magic = true;

            item.UseSound = SoundID.Item20;
			item.shoot = mod.ProjectileType<Necro_Staff_Projectile>();

       
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 5 + Main.rand.Next(0); // 4 or 5 shots
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5)); // 30 degree spread.
                                                                                                                // If you want to randomize the speed to stagger the projectiles
                                                                                                                 float scale = 1f - (Main.rand.NextFloat() * .8f);
                                                                                                                 perturbedSpeed = perturbedSpeed * scale; 
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false; // return false because we don't want tmodloader to shoot projectile
        }
    }
}
