using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using LacunaMod;

namespace LacunaMod.Projectiles
{
    public class CloakRecharge : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 6;
        }
        public override void SetDefaults()
        {
            projectile.width = 80;
            projectile.height = 56;
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
            int FrameTimer = 7;
            Player player = Main.player[projectile.owner];
            projectile.position.X = player.MountedCenter.X - (float)(projectile.width / 2);
            projectile.position.Y = player.MountedCenter.Y - 39;
            projectile.direction = player.direction;
            FrameTimer--;
            if (++projectile.frameCounter >= 7)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame > 5)
                {
                    projectile.Kill();
                }
            }
        }
    }
}
 