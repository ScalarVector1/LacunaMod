using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
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
        public bool glassshell = false;

        // Armor
        public bool glasschest = false;
        public bool glassset = false;
        public bool RealConsumeAmmo = true;

        public override void UpdateEquips(ref bool wallSpeedBuff, ref bool tileSpeedBuff, ref bool tileRangeBuff)
        {
            if (glassshell)
            {
                if (player.statLife > (player.statLifeMax2 / 4))
                {
                    BoostAllDamage(15f);
                    player.statDefense -= (int)(player.statDefense * .15);
                }
                else if (player.statLife < (player.statLifeMax2 / 4))
                {
                    BoostAllDamage(-20f);
                    player.statDefense -= (int)(player.statDefense * .15);
                }
            }
        }
        public override bool ConsumeAmmo(Item weapon, Item ammo)
        {
            if (glasschest)
            {
                if (Main.rand.Next(1, 21) == 1)
                {
                    //Main.NewText("Chest");
                    RealConsumeAmmo = false;
                }
                else
                {
                    RealConsumeAmmo = true;
                }
            }
            else
            {
                RealConsumeAmmo = true;
            }
            // if any more items reduce ammo consume chance, add them above here.
            return RealConsumeAmmo;
        }

        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (glassset)
            {
                Main.PlaySound(SoundID.Shatter, player.Center);
                Main.PlaySound(new LegacySoundStyle(2, 27, Terraria.Audio.SoundType.Sound), player.Center);
            }
            return true;
        }

        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (proj.ranged && enchantedthorn)
                target.AddBuff(BuffID.Poisoned, 12 * 60);
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

        public override void ResetEffects()
        {
            retribution = false;
            glassset = false;
            glasschest = false;
        }

    }
}
