using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LacunaMod.Projectiles.Hostile
{
    public class King_Tesla_Projectile : ModProjectile
    {

        public override void SetDefaults()
        {
            
            projectile.width = 18;
            projectile.height = 34;
            projectile.hostile = true;
            projectile.melee = true;
            projectile.penetrate = 100;
            projectile.aiStyle = 5;
            projectile.timeLeft = 600;

        }

        public override void AI()
        {
            if (Main.rand.Next(1) == 0)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Necro_Dust"), projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f);
            }

      
            
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
    }
}