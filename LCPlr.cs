
using Terraria.Audio;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameInput;
using System.Linq;

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

        //Testing permanent upgrades
        public bool Wind = false;
        public int windtimer = 0;
        private const int TeleCloakCap = 1;
        public bool TeleCloak = false;
        public int teletimer = 0;
        private const int BoltCap = 1;
        public bool Bolt = false;
        public int bolttimer = 0;
        public bool justzapped = false;
        public bool Zephyr = false;
        public int ImpactDelay = 0;

        public override TagCompound Save()
        {
            return new TagCompound {
                {"TeleCloak", TeleCloak},
                {"Bolt", Bolt},
                {"Zephyr", Zephyr},
                {"Wind", Wind}
            };

        }
        public override void Load(TagCompound tag)
        {
            TeleCloak = tag.GetBool("TeleCloak");
            Bolt = tag.GetBool("Bolt");
            Zephyr = tag.GetBool("Zephyr");
            Wind = tag.GetBool("Wind");
        }
        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (LacunaMod.CloakKey.JustPressed && TeleCloak == true && teletimer == 0)
            {

                //Copied form vanilla RoD code
                teletimer = 300;
                Vector2 vector26 = default(Vector2);
                vector26.X = (float)Main.mouseX + Main.screenPosition.X;
                if (player.gravDir == 1f)
                {
                    vector26.Y = (float)Main.mouseY + Main.screenPosition.Y - (float)player.height;
                }
                else
                {
                    vector26.Y = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY;
                }
                float x = vector26.X;
                x -= (float)(player.width / 2);
                if (vector26.X > 50f && vector26.X < (float)(Main.maxTilesX * 16 - 50) && vector26.Y > 50f && vector26.Y < (float)(Main.maxTilesY * 16 - 50))
                {
                    int num270 = (int)(vector26.X / 16f);
                    int num271 = (int)(vector26.Y / 16f);
                    if ((Main.tile[num270, num271].wall != 87 || (double)num271 <= Main.worldSurface || NPC.downedPlantBoss) && !Collision.SolidCollision(vector26, player.width, player.height))
                    {
                        player.Teleport(vector26, 1, 0);
                        NetMessage.SendData(65, -1, -1, null, 0, (float)player.whoAmI, vector26.X, vector26.Y, 1, 0, 0);

                    }
                }
            }
            else if (LacunaMod.CloakKey.JustPressed && TeleCloak == true && teletimer > 0)
            {
                Main.PlaySound(SoundID.Shatter, player.Center);
            }
            else if (LacunaMod.CloakKey.JustPressed)
            {

            }
           
            if (player.TouchedTiles.Count > 0)
            {
                Main.PlaySound(SoundID.Item9, player.Center);
            }
                         
            if (LacunaMod.BoltKey.JustPressed && Bolt == true && bolttimer == 0 && player.TouchedTiles.Count == 0)// add a solid block test here         
            {
                justzapped = true;
                Vector2 vel = new Vector2(0f, 0f);
                Projectile.NewProjectile(player.Center, vel, mod.ProjectileType("Lightning"), 1, 0f, 0, 0, 1);
                Main.PlaySound(SoundID.Item9, player.Center);
            }
            else
            {
            }
            if (justzapped == true) // tee is a dummy value that counts down while smashing, should be replaced with a test for if the player is on a solid block
            {
                bolttimer = 180;
                player.maxFallSpeed += 65f;
                player.velocity.Y += 65f;
                player.velocity.X = 0;
                player.controlJump = false;
                player.controlDown = false;
                player.controlLeft = false;
                player.controlRight = false;
                player.controlUp = false;
                ImpactDelay = 2;
            }
                if (player.TouchedTiles.Count > 0 && justzapped == true && ImpactDelay == 0)
                {
                    Vector2 vel = new Vector2(0f, 0f);
                    Projectile.NewProjectile(player.Center, vel, mod.ProjectileType("Shock"), 1, 0f, 0, 0, 1);
                    Main.PlaySound(SoundID.Item14, player.Center);
                    justzapped = false;
                    
                }


                
            
            if (player.TouchedTiles.Count > 0 && justzapped == true && ImpactDelay == 0) 
            {
                player.maxFallSpeed -= 65f;
                player.velocity.Y -= 65f;

            }

            if (teletimer == 1)
            {
                int CloakDirection = player.direction;
                for (int r = 0; r > 15; r++)
                {
                    Dust dust;
                    // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                    Vector2 position = Main.LocalPlayer.Center;
                    dust = Main.dust[Terraria.Dust.NewDust(position, 30, 30, 66, 2.105263f, 3.684211f, 0, new Color(255, 255, 255), 1f)];
                    dust.noGravity = true;
                }

            }
        }

        public override void UpdateEquips(ref bool wallSpeedBuff, ref bool tileSpeedBuff, ref bool tileRangeBuff)
        {
            if (glassshell)
            {
                if (player.statLife > (player.statLifeMax2 / 4))
                {
                    BoostAllDamage(0.15f);
                    player.statDefense -= (int)(player.statDefense * .85);
                }
                else if (player.statLife < (player.statLifeMax2 / 4))
                {
                    BoostAllDamage(0.80f);
                    player.statDefense -= (int)(player.statDefense * .85);
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
            if (teletimer > 0)
            {
                teletimer--;
            }
            if (bolttimer > 0)
            {
                bolttimer--;
            }
            if (ImpactDelay > 0)
            {
                ImpactDelay--;
            }

        }

    }
}
