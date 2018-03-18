using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LacunaMod.Items.Weapons.Magic
{
    public class FusedMagSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystal Fang");
        }

        public override void SetDefaults()
        {
            item.SetSize(32, 46);
            item.magic = true;
            item.damage = 25;
            item.useTime = 34;
            item.useAnimation = 34;
            item.knockBack = 2f;
            item.crit = 4;
            item.value = 178;
            item.rare = 2;
        }
    }
}
