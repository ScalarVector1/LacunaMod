using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.Enums;

namespace LacunaMod.Tiles.Castle_Deco
{
    public class King_Banner_Wall_Arrow : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileLavaDeath[Type] = false;
            Main.tileFrameImportant[Type] = true;

            TileObjectData.newTile.Width = 4;//Width of the tile in blocks
            TileObjectData.newTile.Height = 4;//Height of the tile in blocks
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16 };//add an extra 16 for every tile of height the tile has, this tile is 2 tall so you would have 2 16s
            TileObjectData.newTile.UsesCustomCanPlace = true;
            TileObjectData.newTile.CoordinateWidth = 16;//dont change
            TileObjectData.newTile.CoordinatePadding = 2;//dont change
            TileObjectData.newTile.Origin = new Point16(0, 0);
            TileObjectData.addTile(Type);

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Castle Arrow Banner");//Map name
            AddMapEntry(new Color(79, 91, 133), name);//Map color, dont change for castle stuff
            dustType = mod.DustType("Castle_Dust");//Use the castle dust
            disableSmartCursor = true;
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 48, 32, mod.ItemType("King_Banner_Wall_Arrow_Icon"));
        }
    }
}