﻿using Terraria;
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
			return player.GetModPlayer<LCPlr>().TeleCloak == false;
		}
		public override bool UseItem(Player player)
		{
<<<<<<< HEAD
			player.GetModPlayer<LCPlr>().TeleCloak += 1;
            UI.Cloak.CloakUI.visible = true;
            return true;
=======
			player.GetModPlayer<LCPlr>().TeleCloak = true;
			return true;
>>>>>>> 53a53d1fb2693ed22e0243d61feebda7e0803e18
		}

	}
}
