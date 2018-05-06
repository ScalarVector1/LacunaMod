using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using LacunaMod;

namespace LacunaMod.Projectiles
{
    public class Shock : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 9;
        }
        public override void SetDefaults()
        {
            projectile.width = 120;
            projectile.height = 44;
            projectile.friendly = true;
            projectile.timeLeft = 18;
            projectile.tileCollide = false;


        }
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }

        public override void AI()
        {

            
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
 