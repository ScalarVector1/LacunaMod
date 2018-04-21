using LTEST.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LTEST.Items
{
	public class Coka : ModItem

	{
		public override void SetDefaults()
		{
			item.shootSpeed = 7f;
			item.damage = 1;
			item.knockBack = 0.001f;
			item.useStyle = 1;
			item.useAnimation = 43;
			item.useTime = 1;
			item.width = 40;
			item.height = 40;
			item.maxStack = 1;
			item.rare = 3;

			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
            item.melee = true;

            item.UseSound = SoundID.Item15;
			item.shoot = mod.ProjectileType<Cok>();

       
		}
    }
}
