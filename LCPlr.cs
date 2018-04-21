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
        public int glasstimer = 0;

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
            if (glasschest && RealConsumeAmmo == true)
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
                if (glasstimer == 0)
                {
                    Main.PlaySound(SoundID.Item28, player.Center);
                    for (int i = 0; i < Main.rand.Next(1, 5); i++)
                    {
                        Projectile.NewProjectile(player.position.X, player.position.Y, Main.rand.Next(-2, 3), Main.rand.Next(-2, 3), mod.ProjectileType("GlassShard"), 5, 5, player.whoAmI);
                    }
                    glasstimer = 180;
                }
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
            if (glasstimer > 0)
            {
                glasstimer--;
            }
        }
    }
}
