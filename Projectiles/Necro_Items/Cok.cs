using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LacunaMod.Projectiles.Necro_Items
{
    public class Cok : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 10;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.penetrate = 1;
            projectile.aiStyle = 3;
            projectile.velocity.X = 1f;
            projectile.velocity.Y = 1f;
            projectile.timeLeft = 50;
        }

        public override void AI()
        {
            if (Main.rand.Next(2) == 0)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Necro_Dust"), projectile.velocity.X * 0.9f, projectile.velocity.Y * 0.9f);
            }
            int willdie = 1;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)

        {
           
            projectile.timeLeft = 0;
            if (projectile.timeLeft <= 0)
            {
                projectile.Kill();
            }
            else
            {
                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -oldVelocity.X;
                }
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y;
                }
                Main.PlaySound(SoundID.Item10, projectile.position);
            }
            return false;
        }
    }
}