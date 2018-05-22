using Terraria;
using Terraria.ModLoader;

namespace LacunaMod.Items.KeyItems
{

    class Feather : ModItem
	{


		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Zephyr Feather");
            Tooltip.SetDefault("PERMANENTLY Grants infinite flight time\n Press N to toggle gliding");
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
			return player.GetModPlayer<LCPlr>().Zephyr == false;
		}
		public override bool UseItem(Player player)
		{

			player.GetModPlayer<LCPlr>().Zephyr = true;

            return true;



		}

	}
}
