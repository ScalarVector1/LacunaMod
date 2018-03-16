using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace LacunaMod
{
    public static class ItemExtension
    {
        public static void SetSize(this Item item, int width, int height)
        {
            item.width  = width;
            item.height = height;
        }

        public static void SetSize(this Item item, int[] size)
        {
            if (size.Length == 2)
            {
                item.width  = size[0];
                item.height = size[1];
            }
        }
    }
}
