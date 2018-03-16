using Terraria;
using Terraria.ModLoader;

namespace LacunaMod.Items.Materials
{
    public class Fuseglass: QuickMaterial
    {
        public override void Data()
        {
            name = "Fuseglass";
            rarity = 2;
            value = 15;
            size = new int[] { 26, 26 };
        }
    }
}
