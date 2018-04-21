using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace LacunaMod.Tiles.Tiles
{
    public class Glass_Tile_Ore : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = false;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            drop = mod.ItemType("Glass_Ore");
            AddMapEntry(new Color(132, 169, 165));
        }





    }
}