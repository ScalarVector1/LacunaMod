using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LacunaMod.Projectiles.Necro_Items
{
    public class Necro_Knife_Projectile : ModProjectile
    {

        public override void SetDefaults()
        {
            
            projectile.width = 18;
            projectile.height = 34;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.penetrate = 1;
            projectile.aiStyle = 2;
            projectile.velocity.X = 8f;
            projectile.velocity.Y = .01f;
            projectile.timeLeft = 50;
            projectile.alpha = 0;
        }

        public override void AI()
        {
            if (Main.rand.Next(1) == 0)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Necro_Dust"), projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f);
            }

                projectile.alpha += 5;
            
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
    }
}