using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LacunaMod
{
    public class LCPlr : ModPlayer
    {
        public bool retribution = false;

        public override void ResetEffects()
        {
            retribution = false;
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
