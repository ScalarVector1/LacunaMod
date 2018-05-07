using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using LacunaMod;

namespace LacunaMod.Projectiles
{
    public class LightningHam : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 6;
        }
        public override void SetDefaults()
        {
            projectile.width = 60;
            projectile.height = 176;
            projectile.friendly = true;
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
            projectile.position.X = player.MountedCenter.X - (float)(projectile.width / 2);
            projectile.position.Y = player.MountedCenter.Y - (float)(projectile.height / 1.28);
            if (++projectile.frameCounter >= 4)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 6)
                {
                    projectile.frame = 0;
                }
            }
            if (player.velocity.Y == 0)
            {
                projectile.timeLeft = 0;
            }

        }
        
    }
}
 