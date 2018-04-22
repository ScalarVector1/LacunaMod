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
        }
    }
}
