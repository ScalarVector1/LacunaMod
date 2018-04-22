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
        bool kill = false;
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            int hits = Main.rand.Next(2, 3);
            if (hits == 0)
            {
                kill = true;
            }
        }
        public override void Kill(int timeLeft)
        {
            if (kill)
            {
                timeLeft = 0;
            }
        }
    }
}
