using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LacunaMod.Projectiles.Necro_Items
{
    public class Necro_Staff_Projectile : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = 4;
            projectile.timeLeft = 200;
            projectile.aiStyle = 48;
        }

        /*public override void AI()
        {
            if (Main.rand.Next(2) == 0)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Necro_Dust"), projectile.velocity.X * 0.9f, projectile.velocity.Y * 0.9f);
            }
            int willdie = 1;



            Main.PlaySound(SoundID.Item10, projectile.position);
            int num4;
            for (int r; r < 20; r++)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("Necro_Dust"), 0.2f, 0.2f);
            }


            bool flag10 = false;
            if (velocity.X != projectile.velocity.X)
            {
                if (Math.Abs(velocity.X) > 4f)
                {
                    flag10 = true;
                }
                projectile.position.X = projectile.position.X + projectile.velocity.X;
                projectile.velocity.X = (0f - velocity.X) * 0.2f;
            }
            if (velocity.Y != projectile.velocity.Y)
            {
                if (Math.Abs(velocity.Y) > 4f)
                {
                    flag10 = true;
                }
                projectile.position.Y = projectile.position.Y + projectile.velocity.Y;
                projectile.velocity.Y = (0f - velocity.Y) * 0.2f;
            }
            ai[0] = 1f;
            if (flag10)
            {
                netUpdate = true;
                Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
                Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 1, 1f, 0f);
            }
            if (projectile.wet)
            {
                wetVelocity = projectile.velocity;
            }
        }
    }
    */

    }
}
 