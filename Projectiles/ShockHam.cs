using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using LacunaMod;

namespace LacunaMod.Projectiles
{
    public class ShockHam : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 9;
        }
        public override void SetDefaults()
        {
            projectile.width = 172;
            projectile.height = 30;
            projectile.friendly = true;
            projectile.timeLeft = 18;
            projectile.tileCollide = false;
            projectile.penetrate = 2000;



        }
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            projectile.position.Y = player.MountedCenter.Y - (float)(projectile.height / 6);
            if (++projectile.frameCounter >= 2)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 9)
                {
                    projectile.frame = 0;
                }
            }


        }
        
    }
}
 