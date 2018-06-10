
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace LacunaMod.Items.Materials
{
	public class TESTSPRITE : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Infused Tesla");
            Tooltip.SetDefault("Zap!");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(3, 9));
        }

		public override void SetDefaults()
		{
			item.width = 60;
			item.height = 102;
			item.maxStack = 999;
			item.value = 100;
			item.rare = 3;
		}

	}
}
