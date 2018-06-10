using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LacunaMod.NPCs.Hostile
{
	public class King_Tesla : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Infused Tesla");
            Main.npcFrameCount[npc.type] = 10;
		}

		public override void SetDefaults()
		{
			npc.width = 60;
			npc.height = 102;
			npc.damage = 30;
			npc.defense = 40;
			npc.lifeMax = 500;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath14;
			npc.value = 60f;
			npc.knockBackResist = 9999f;
			npc.aiStyle = -1;

		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return SpawnCondition.OverworldNightMonster.Chance * 3f;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			for (int i = 0; i < 10; i++)
			{
				int dustType = Main.rand.Next(139, 143);
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}

        // These const ints are for the benefit of the programmer. Organization is key to making an AI that behaves properly without driving you crazy.
        // Here I lay out what I will use each of the 4 npc.ai slots for.
        const int AI_State_Slot = 0;
        const int AI_Timer_Slot = 1;
        const int AI_Unused_Slot_3 = 3;
        public bool Chargeanim = false;

        // npc.localAI will also have 4 float variables available to use. With ModNPC, using just a local class member variable would have the same effect.
        const int Local_AI_Unused_Slot_0 = 0;
        const int Local_AI_Unused_Slot_1 = 1;
        const int Local_AI_Unused_Slot_2 = 2;
        const int Local_AI_Unused_Slot_3 = 3;

        // Here I define some values I will use with the State slot. Using an ai slot as a means to store "state" can simplify things greatly. Think flowchart.
        const int State_Asleep = 0;
        const int State_Notice = 1;
        const int State_Shoot = 2;
 

        // This is a property (https://msdn.microsoft.com/en-us/library/x9fsa0sw.aspx), it is very useful and helps keep out AI code clear of clutter.
        // Without it, every instance of "AI_State" in the AI code below would be "npc.ai[AI_State_Slot]". 
        // Also note that without the "AI_State_Slot" defined above, this would be "npc.ai[0]".
        // This is all to just make beautiful, manageable, and clean code.
        public float AI_State
        {
            get { return npc.ai[AI_State_Slot]; }
            set { npc.ai[AI_State_Slot] = value; }
        }

        public float AI_Timer
        {
            get { return npc.ai[AI_Timer_Slot]; }
            set { npc.ai[AI_Timer_Slot] = value; }
        }



        // AdvancedFlutterSlime will need: float in water, diminishing aggo, spawn projectiles.

        // Our AI here makes our NPC sit waiting for a player to enter range, jumps to attack, flutter mid-fall to stay afloat a little longer, then falls to the ground. Note that animation should happen in FindFrame
        public override void AI()
        {
            // The npc starts in the asleep state, waiting for a player to enter range
            if (AI_State == State_Asleep)
 
            {
                // TargetClosest sets npc.target to the player.whoAmI of the closest player. the faceTarget parameter means that npc.direction will automatically be 1 or -1 if the targeted player is to the right or left. This is also automatically flipped if npc.confused
                npc.TargetClosest(true);
                // Now we check the make sure the target is still valid and within our specified notice range (500)
                if (npc.HasValidTarget && Main.player[npc.target].Distance(npc.Center) < 500f)
                {
                    // Since we have a target in range, we change to the Notice state. (and zero out the Timer for good measure)
                    AI_State = State_Notice;
                    AI_Timer = 0;
                }
            }
            // In this state, a player has been targeted
            else if (AI_State == State_Notice)
            {
 
                /// If the targeted player is in attack range (250).
                if (Main.player[npc.target].Distance(npc.Center) < 500f)
                {
                    // Here we use our Timer to wait .33 seconds before actually jumping. In FindFrame you'll notice AI_Timer also being used to animate the pre-jump crouch
                    AI_Timer++;
                    if (AI_Timer >= 130 + Main.rand.Next(50))
                    {
                        AI_State = State_Shoot;
                        AI_Timer = 0;
                    }
                }
                else
                {
                    npc.TargetClosest(true);
                    if (!npc.HasValidTarget || Main.player[npc.target].Distance(npc.Center) > 500f)
                    {
                        // Out targeted player seems to have left our range, so we'll go back to sleep.
                        AI_State = State_Asleep;
                        AI_Timer = 0;
                    }
                }
            }
            // In this state, we are in the jump. 
            else if (AI_State == State_Shoot)
            {
                AI_Timer++;
                Player player = Main.player[npc.target];
                if (AI_Timer > 5)
                {
                    // after .66 seconds, we go to the hover state. // TODO, gravity?
                    Vector2 delta = Main.player[npc.target].Center - npc.Center;
                    float magnitude = (float)Math.Sqrt(delta.X * delta.X + delta.Y * delta.Y);
                    if (magnitude > 0)
                    {
                        delta *= 5f / magnitude;
                    }
                    else
                    {
                        delta = new Vector2(0f, 5f);
                    }
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 25, delta.X * 2, delta.Y * 2, mod.ProjectileType("King_Tesla_Projectile"), 5, 10f, Main.myPlayer, player.Center.X, player.Center.Y);
                    AI_Timer = 0;
                    AI_State = State_Notice;
                    
                }
            }
            // In this state, our npc starts to flutter/fly a little to make it's movement a little bit interesting.
        }

            // Our texture is 32x32 with 2 pixels of padding vertically, so 34 is the vertical spacing.  These are for my benefit and the numbers could easily be used directly in the code below, but this is how I keep code organized.
            const int Frame_Passive_1 = 0;
            const int Frame_Passive_2 = 1;
            const int Frame_Passive_3 = 2;
            const int Frame_Passive_4 = 3;
            const int Frame_Passive_5 = 4;
            const int Frame_Passive_6 = 5;
            const int Frame_Passive_7 = 6;
            const int Frame_Passive_8 = 7;
            const int Frame_Passive_9 = 8;
            const int Frame_Charge = 9;
        


        // Here in FindFrame, we want to set the animation frame our npc will use depending on what it is doing.
        // We set npc.frame.Y to x * frameHeight where x is the xth frame in our spritesheet, counting from 0. For convenience, I have defined some consts above.
        public override void FindFrame(int frameHeight)
        {
            // This makes the sprite flip horizontally in conjunction with the npc.direction.
            npc.spriteDirection = npc.direction;

            // For the most part, our animation matches up with our states.
            if (AI_State == State_Notice)
            {
                // npc.frame.Y is the goto way of changing animation frames. npc.frame starts from the top left corner in pixel coordinates, so keep that in mind.

                npc.frameCounter++;
                if (npc.frameCounter < 2)
                {
                    npc.frame.Y = Frame_Passive_1 * frameHeight;
                }
                else if (npc.frameCounter < 4)
                {
                    npc.frame.Y = Frame_Passive_2 * frameHeight;
                }
                else if (npc.frameCounter < 6)
                {
                    npc.frame.Y = Frame_Passive_3 * frameHeight;
                }
                else if (npc.frameCounter < 8)
                {
                    npc.frame.Y = Frame_Passive_4 * frameHeight;
                }
                else if (npc.frameCounter < 10)
                {
                    npc.frame.Y = Frame_Passive_5 * frameHeight;
                }
                else if (npc.frameCounter < 12)
                {
                    npc.frame.Y = Frame_Passive_6 * frameHeight;
                }
                else if (npc.frameCounter < 14)
                {
                    npc.frame.Y = Frame_Passive_7 * frameHeight;
                }
                else if (npc.frameCounter < 16)
                {
                    npc.frame.Y = Frame_Passive_8 * frameHeight;
                }
                else if (npc.frameCounter < 18)
                {
                    npc.frame.Y = Frame_Passive_9 * frameHeight;
                    npc.frameCounter = 0;
                }
            }
            else if (AI_State == State_Asleep)
            {
                // npc.frame.Y is the goto way of changing animation frames. npc.frame starts from the top left corner in pixel coordinates, so keep that in mind.

                npc.frameCounter++;
                if (npc.frameCounter < 4)
                {
                    npc.frame.Y = Frame_Passive_1 * frameHeight;
                }
                else if (npc.frameCounter < 8)
                {
                    npc.frame.Y = Frame_Passive_2 * frameHeight;
                }
                else if (npc.frameCounter < 12)
                {
                    npc.frame.Y = Frame_Passive_3 * frameHeight;
                }
                else if (npc.frameCounter < 16)
                {
                    npc.frame.Y = Frame_Passive_4 * frameHeight;
                }
                else if (npc.frameCounter < 20)
                {
                    npc.frame.Y = Frame_Passive_5 * frameHeight;
                }
                else if (npc.frameCounter < 24)
                {
                    npc.frame.Y = Frame_Passive_6 * frameHeight;
                }
                else if (npc.frameCounter < 28)
                {
                    npc.frame.Y = Frame_Passive_7 * frameHeight;
                }
                else if (npc.frameCounter < 32)
                {
                    npc.frame.Y = Frame_Passive_8 * frameHeight;
                }
                else if (npc.frameCounter < 36)
                {
                    npc.frame.Y = Frame_Passive_9 * frameHeight;
                    npc.frameCounter = 0;
                }
            }
            else if (AI_State == State_Shoot)
            {
                npc.frameCounter = 0;
                npc.frame.Y = Frame_Charge * frameHeight;
                npc.frameCounter = 0;

            }
            else if (AI_State == State_Asleep)
            {
                // npc.frame.Y is the goto way of changing animation frames. npc.frame starts from the top left corner in pixel coordinates, so keep that in mind.

                npc.frameCounter++;
                if (npc.frameCounter < 4)
                {
                    npc.frame.Y = Frame_Passive_1 * frameHeight;
                }
                else if (npc.frameCounter < 8)
                {
                    npc.frame.Y = Frame_Passive_2 * frameHeight;
                }
                else if (npc.frameCounter < 12)
                {
                    npc.frame.Y = Frame_Passive_3 * frameHeight;
                }
                else if (npc.frameCounter < 16)
                {
                    npc.frame.Y = Frame_Passive_4 * frameHeight;
                }
                else if (npc.frameCounter < 20)
                {
                    npc.frame.Y = Frame_Passive_5 * frameHeight;
                }
                else if (npc.frameCounter < 24)
                {
                    npc.frame.Y = Frame_Passive_6 * frameHeight;
                }
                else if (npc.frameCounter < 28)
                {
                    npc.frame.Y = Frame_Passive_7 * frameHeight;
                }
                else if (npc.frameCounter < 32)
                {
                    npc.frame.Y = Frame_Passive_8 * frameHeight;
                }
                else if (npc.frameCounter < 36)
                {
                    npc.frame.Y = Frame_Passive_9 * frameHeight;
                    npc.frameCounter = 0;
                }
            }


        }
    }
}

	

