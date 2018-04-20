using Terraria.ID;
using Terraria.ModLoader;

namespace LTEST.Items
{
	public class King_Material : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Aurium");
            Tooltip.SetDefault("Not quite gold");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.value = 100;
			item.rare = 3;
		}

	}
}
