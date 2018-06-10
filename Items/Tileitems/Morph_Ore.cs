using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
// If you are using c# 6, you can use: "using static Terraria.Localization.GameCulture;" which would mean you could just write "DisplayName.AddTranslation(German, "");"
using Terraria.Localization;
using LacunaMod;

namespace LacunaMod.Items.Tileitems
{


    public class Morph_Ore : ModItem
    
    {
        public string Tex = "LacunaMod/Items/Tileitems/Morph_Ore_0";
        public void CanSmelt()
        {
            LCPlr ms = new LCPlr();
            if (ms.MorphSmelt == true)
            {
                Tex = "LacunaMod/Items/Tileitems/Morph_Ore_1";
            }
            else
            {
                Tex = "LacunaMod/Items/Tileitems/Morph_Ore_0";
            }
        }
        public override string Texture
        {
            get { return Tex; }
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Morphite Ore");
            Tooltip.SetDefault("Morphs to a useable form near evil");
        }

        public override void SetDefaults()
        {
            item.width = 12;
            item.height = 12;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.createTile = mod.TileType("Morph_Tile_Ore");
        }




    }
}