using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LacunaMod
{
    public class LGlbItm : GlobalItem
    {
        public override bool UseItem(Item item, Player player)
        {
            if (!item.autoReuse)
                item.autoReuse = true; // remove later
            return base.UseItem(item, player);
        }
    }
}
