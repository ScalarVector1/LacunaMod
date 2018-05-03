using Terraria;
using Terraria.ModLoader;

namespace LacunaMod.Items.KeyItems
{

    class Cloak : ModItem
	{


		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Zzelera's Cloak");
            Tooltip.SetDefault("PERMANENTLY Grants the ability to teleport\n Press Q to teleport\n 5 second cooldown");
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
			return player.GetModPlayer<LCPlr>().TeleCloak < 1;
		}

		public override bool UseItem(Player player)
		{
			player.GetModPlayer<LCPlr>().TeleCloak += 1;
			return true;
		}

	}
}
