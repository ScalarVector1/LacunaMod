
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
        public bool justzapped2 = false;
        public bool justzapped3 = false;
        public bool justzapped4 = false;
        public bool Zephyr = false;
        public int ImpactDelay = 0;
        public bool Hammer = false;

        public override TagCompound Save()
        {
            return new TagCompound {
                {"TeleCloak", TeleCloak},
                {"Bolt", Bolt},
                {"Zephyr", Zephyr},
                {"Wind", Wind},
                {"Hammer", Hammer}
            };

        }
        public override void Load(TagCompound tag)
        {
            TeleCloak = tag.GetBool("TeleCloak");
            Bolt = tag.GetBool("Bolt");
            Zephyr = tag.GetBool("Zephyr");
            Wind = tag.GetBool("Wind");
            Hammer = tag.GetBool("Hammer");
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
           
                         
            if (LacunaMod.BoltKey.JustPressed && Bolt == true && bolttimer == 0 && player.velocity.Y !=0 && Hammer == false)//if the hotkey is pressed, the upgrade is consumed, bolt is not on cooldown, and the player is not still vertically      
            {
                justzapped = true;//for actively zapping
                justzapped2 = true;//for the whole zap projedure
                Vector2 vel = new Vector2(0f, 0f);//prep for projectile
                Projectile.NewProjectile(player.Center, vel, mod.ProjectileType("Lightning"), 1, 0f, 0, 0, 1);//plays the zap effects on player
                Main.PlaySound(SoundID.Item9, player.Center);//zap sounds at start
            }
            else
            {
            }
            if (justzapped2 == true)
            {
                player.noFallDmg = true;    
            }
            if (justzapped == true) 
            {
                bolttimer = 180;//cooldown set to 180 frames
                player.maxFallSpeed += 65f;//allow fast falling
                player.velocity.Y += 65f;//propel downwards
                player.velocity.X = 0;//stop any horizontal movement
                player.controlJump = false;//prevents inputs untill landing
                player.controlDown = false;
                player.controlLeft = false;
                player.controlRight = false;
                player.controlUp = false;
                ImpactDelay = 2;//set value of the impact delay
                
            }
            if (player.TouchedTiles.Count > 0 && justzapped == true && ImpactDelay != 0)//set justzapped to false if they have touched the ground and there is still impact delay
            {                
                justzapped = false;//ends the zap and allows movement again

            }
            if (justzapped == false && justzapped2 == true)//if the player has stopped zapping but is still in the smash projedure
            {
                ImpactDelay -= 1;//tick down the delay
            }
                if (ImpactDelay == 0 && justzapped2 == true)//if the delay is over and the player is still in the projedure
                {
                Vector2 vel = new Vector2(0f, 0f);//prep for projectile
                Projectile.NewProjectile(player.Center, vel, mod.ProjectileType("Shock"), 1, 0f, 0, 0, 1);//play impact effects on player
                Main.PlaySound(SoundID.Item14, player.Center);//play impact sound
                justzapped2 = false;//end the smash procedure


            }
// Upgraded version
            if (LacunaMod.BoltKey.JustPressed && Bolt == true && bolttimer == 0 && player.velocity.Y != 0 && Hammer == true)//if the hotkey is pressed, the upgrade is consumed, bolt is not on cooldown, and the player is not still vertically and the hammer is consumed      
            {
                justzapped3 = true;//for actively zapping
                justzapped4 = true;//for the whole zap projedure
                Vector2 vel = new Vector2(0f, 0f);//prep for projectile
                Projectile.NewProjectile(player.Center, vel, mod.ProjectileType("LightningHam"), 1, 0f, 0, 0, 1);//plays the zap effects on player
                
                Main.PlaySound(SoundID.Item9, player.Center);//zap sounds at start
            }
            else
            {
            }
            if (justzapped4 == true)
            {
                player.noFallDmg = true;
            }
            if (justzapped3 == true)
            {
                bolttimer = 180;//cooldown set to 180 frames
                player.maxFallSpeed += 75f;//allow fast falling
                player.velocity.Y += 75f;//propel downwards
                player.velocity.X = 0;//stop any horizontal movement
                player.controlJump = false;//prevents inputs untill landing
                player.controlDown = false;
                player.controlLeft = false;
                player.controlRight = false;
                player.controlUp = false;
                ImpactDelay = 2;//set value of the impact delay

            }
            if (player.TouchedTiles.Count > 0 && justzapped3 == true && ImpactDelay != 0)//set justzapped to false if they have touched the ground and there is still impact delay
            {
                justzapped3 = false;//ends the zap and allows movement again

            }
            if (justzapped3 == false && justzapped4 == true)//if the player has stopped zapping but is still in the smash projedure
            {
                ImpactDelay -= 1;//tick down the delay
            }
            if (ImpactDelay == 0 && justzapped4 == true)//if the delay is over and the player is still in the projedure
            {
                Vector2 vel = new Vector2(0f, 0f);//prep for projectile
                Projectile.NewProjectile(player.Center, vel, mod.ProjectileType("ShockHam"), 100, 0f, 0, 0, 1);//play impact effects on player
                Projectile.NewProjectile(player.Center, vel, mod.ProjectileType("Shock"), 1, 0f, 0, 0, 1);//play impact effects on player
                Main.PlaySound(SoundID.Item14, player.Center);//play impact sound
                justzapped4 = false;//end the smash procedure


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

            

        }

    }
}
