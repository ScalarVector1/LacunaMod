using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LacunaMod.Items.Tools
{
    public class WAND : QuickTool
    {
        public override void Data()
        {
            name = "Wand of Scalie";
            tooltip = "You shouldn't have this n/(Unless you're me, ofcourse)";
            pow = new Power(ToolType.PickaxeAxe, 9000, 9000);
            damage = 20000000;
            useTime = 1;
            useAnim = 5;
            value = 999999;
            rarity = -1;
            kb = 1f;
            size = new int[] { 46, 46 };
        }


    }
}
