using Terraria;
using Terraria.ModLoader;

namespace LacunaMod.Items.Materials
{
    public class Glass_Fossil : QuickMaterial
    {
        public override void Data()
        {
            name = "Fused Fossil";
            rarity = 2;
            value = 8;
            size = new int[] { 32, 32 };
        }
    }
}
