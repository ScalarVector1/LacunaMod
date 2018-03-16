//using Terraria;
//using Terraria.ID;
//using Terraria.ModLoader;

//namespace LacunaMod.NPCs
//{
//    public class FusedScarab : ModNPC
//    {
//        public override void SetStaticDefaults()
//        {
//            DisplayName.SetDefault("Fused Scarab");
//            Main.npcFrameCount[npc.type] = 4;
//        }

//        public override void SetDefaults()
//        {
//            npc.width = 18;
//            npc.height = 40;
//            npc.damage = 10;
//            npc.defense = 0;
//            npc.lifeMax = 200;
//            npc.value = 15f;
//            npc.knockBackResist = 0.65f;
//            npc.aiStyle = 40; // spider ai
//            aiType = NPCID.WallCreeper;
//            animationType = NPCID.WallCreeper;
//        }

//        public override float SpawnChance(NPCSpawnInfo spawnInfo)
//        {
//            return SpawnCondition.DesertCave.Chance * 2f;
//        }

//        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
//        {
//            npc.damage = 12;
//            npc.lifeMax = 250;
//        }
//    }
//}