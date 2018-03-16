using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LacunaMod.Items.Consumables
{
    public class FuseglassBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fuseglass Bag");
            Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
        }

        public override void SetDefaults()
        {
            item.maxStack = 99;
            item.consumable = true;
            item.width = 34;
            item.height = 32;
            item.rare = 2;
            item.expert = true;
            bossBagNPC = mod.NPCType(""); //////////
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void OpenBossBag(Player player)
        {
            int num = Main.rand.Next(3) + 1;
            
            switch (num)
            {
                case 0:
                    player.QuickSpawnItem(mod.ItemType("FusedMagSword"));
                    break;
                case 1:
                    player.QuickSpawnItem(mod.ItemType("FusedXbow"));
                    break;
                case 2:
                    player.QuickSpawnItem(mod.ItemType("FusedFlail"));
                    break;
            }
        }
    }
}
