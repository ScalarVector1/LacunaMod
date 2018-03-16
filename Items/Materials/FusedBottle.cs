using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LacunaMod.Items.Materials
{
    public class FusedBottle : QuickMaterial
    {
        public override void Data()
        {
            name = "Fused Bottle";
            rarity = 3;
            value = 1000;
            size = new int[] { 20, 28 };
        }
    }
}
