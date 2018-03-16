using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LacunaMod.Buffs
{
    public class RetributionBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Retribution");
            Description.SetDefault(""); ///////
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<LCPlr>().retribution = true;
            player.GetModPlayer<LCPlr>().BoostAllDamage(15f);
        }
    }
}
