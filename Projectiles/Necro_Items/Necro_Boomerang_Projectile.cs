using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LacunaMod.Projectiles.Necro_Items
{
    public class Necro_Boomerang_Projectile : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 40;
            projectile.height = 40;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.penetrate = 1;
            projectile.aiStyle = 3;
            projectile.velocity.X = 1f;
            projectile.velocity.Y = 1f;
        }

        public override void AI()
        {
            if (Main.rand.Next(1) == 0)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Necro_Dust"), projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f);
            }


                

            
        }
    }
}