using LacunaMod.Projectiles.Necro_Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LacunaMod.Items.Weapons.Necrocatalyst
{
	public class Necro_Boomerang : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cerulean Crescent");
            Tooltip.SetDefault("There and back in a flash.");
        }
        public override void SetDefaults()
		{
			item.shootSpeed = 18f;
			item.damage = 25;
			item.knockBack = 2f;
			item.useStyle = 1;
			item.useAnimation = 24;
			item.useTime = 24;
			item.width = 40;
			item.height = 40;
			item.maxStack = 1;
			item.rare = 5;

			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
            item.melee = true;

            item.UseSound = SoundID.Item7;
			item.shoot = mod.ProjectileType<Necro_Boomerang_Projectile>();

       
		}
        public override bool CanUseItem(Player player)
        {
            for (int i = 0; i < 1000; ++i)
            {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == item.shoot)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
