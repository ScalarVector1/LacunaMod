using Terraria;
using Terraria.ModLoader;

namespace LacunaMod.Items.KeyItems
{

    class Bolt : ModItem
	{


		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Xel-Val Bolt");
            Tooltip.SetDefault("PERMANENTLY Grants the ability to lightning smash\n Press Z to smash\n 3 second cooldown");
		}

		public override void SetDefaults()
		{
            item.SetSize(26, 40);
            item.noMelee = true;
            item.consumable = true;
            item.value = 1500;
            item.rare = 6;
            item.useStyle = 1;
            item.useTime = 15;
            item.useAnimation = 15;
        }

		public override bool CanUseItem(Player player)
		{
			return player.GetModPlayer<LCPlr>().Bolt == false;
		}

		public override bool UseItem(Player player)
		{
			player.GetModPlayer<LCPlr>().Bolt = true;
			return true;
		}

	}
}
