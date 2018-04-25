using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;

namespace LacunaMod.Items.KeyItems
{
	
	class Cloak : ModItem
	{


		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Press P To teleport!");
		}

		public override void SetDefaults()
		{
            item.SetSize(20, 28);
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
			// Any mod that changes statLifeMax to be greater than 500 is broken and needs to fix their code.
			// This check also prevents this item from being used before vanilla health upgrades are maxed out.
			return player.GetModPlayer<LCPlr>().TeleCloak < 1;
		}

		public override bool UseItem(Player player)
		{
			player.GetModPlayer<LCPlr>().TeleCloak += 1;
			return true;
		}

	}
}
