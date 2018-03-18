using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LacunaMod.Items.Weapons.Melee
{
    public class FusedFlail : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystal Chains");
        }

        public override void SetDefaults()
        {
            item.SetSize(40, 32);
            item.melee = true;
            item.damage = 28;
            item.useTime = 40;
            item.useAnimation = 40;
            item.useStyle = 5;
            item.scale = 1.1f;
            item.knockBack = 4f;
            item.value = 134;
            item.crit = 8;
            item.rare = 2;

            item.shoot = mod.ProjectileType("FusedFlailBall");
            item.channel = true;
        }
    }
}
