using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LacunaMod.Items.Weapons.Magic
{
    public class FusedMagSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fuseglass Magic Sword");
        }

        public override void SetDefaults()
        {
            item.SetSize(32, 46);
            item.magic = true;
            item.damage = 13;
            item.useTime = 22;
            item.useAnimation = 22;
            item.knockBack = 2f;
            item.value = 178;
            item.rare = 2;
        }
    }
}
