using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace LacunaMod.Tiles.Tiles
{
    public class King_Tile_Plain_Placed : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = false;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            drop = mod.ItemType("King_Tile_Plain");
            AddMapEntry(new Color(131, 143, 152));
        }





    }
}