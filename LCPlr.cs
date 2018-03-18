using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LacunaMod
{
    public class LCPlr : ModPlayer
    {
        // Buffs
        public bool retribution = false;

        // Accessories
        public bool enchantedthorn = false;

        public override void ResetEffects()
        {
            retribution = false;
        }

        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (proj.ranged && enchantedthorn)
                target.AddBuff(BuffID.Poisoned, 12 * 60);

            base.ModifyHitNPCWithProj(proj, target, ref damage, ref knockback, ref crit, ref hitDirection);
        }

        public void BoostAllDamage(float percent)
        {
            player.meleeDamage += percent;
            player.rangedDamage += percent;
            player.magicDamage += percent;
            player.minionDamage += percent;
            player.thrownDamage += percent;
        }

        public void BoostAllCrit(int percent)
        {
            player.meleeCrit += percent;
            player.rangedCrit += percent;
            player.magicCrit += percent;
            player.thrownCrit += percent;
        }
    }
}
