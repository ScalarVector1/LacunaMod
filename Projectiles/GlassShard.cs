using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LacunaMod.Projectiles
{
    public class GlassShard : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Glass Shard");
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.SpikyBall);
            projectile.width = 10;
            projectile.height = 12;
            projectile.timeLeft = 100;
        }
        public override void AI()
        {
            if (Main.rand.Next(4) == 0)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Glass_Dust"), projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f);
            }





        }
    }
}
