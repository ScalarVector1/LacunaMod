using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LacunaMod.NPCs
{
    public class LacunaRift : ModNPC
    {
        public int counter;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lacuna Rift");
            Main.npcFrameCount[npc.type] = 1;
            counter = 0;
        }

        public override void SetDefaults()
        {
            npc.width = 18;
            npc.height = 40;
            npc.damage = 14;
            npc.defense = 6;
            npc.lifeMax = 2000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath2;
            npc.value = 60f;
            npc.knockBackResist = float.MaxValue;
        }

        public override void AI()
        {
            if ((counter * 60) % 4 == 0)
            {
                NPC.NewNPC((int)npc.position.X + (int)Main.rand.Next(-5, -6), (int)npc.position.Y, NPCID.Zombie);
            }
            counter++;
        }
    }
}
