using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace LacunaMod.Items.Tools
{
    public enum ToolType
    {
        Pickaxe,
        Axe,
        Hammer,
        PickaxeAxe,
        Hamaxe
    }

    public class Power
    {
        public int pickPower;
        public int axePower;
        public int hammerPower;
        
        public Power(ToolType tool, int power1, int power2 = 0)
        {
            switch (tool)
            {
                case ToolType.Pickaxe:
                    pickPower = power1;
                    break;
                case ToolType.Axe:
                    axePower = power1;
                    break;
                case ToolType.Hammer:
                    hammerPower = power1;
                    break;
                case ToolType.PickaxeAxe:
                    pickPower = power1;
                    axePower = power2;
                    break;
                case ToolType.Hamaxe:
                    hammerPower = power1;
                    axePower = power2;
                    break;
            }
        }
    }

    public abstract class QuickTool : ModItem
    {

        public string name;
        public string tooltip;
        public Power pow;
        public int damage;
        public float kb;
        public int useTime;
        public int useAnim;
        public int value;
        public int rarity;
        public int[] size = new int[] { 40, 40 };

        public abstract void Data();

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault(name);
            Tooltip.SetDefault(tooltip);
        }

        public override void SetDefaults()
        {
            item.damage = damage;
            item.melee = true;
            item.SetSize(size);
            item.useTime = useTime;
            item.useAnimation = useAnim;
            item.pick = pow.pickPower;
            item.axe = pow.axePower * 5;
            item.hammer = pow.hammerPower;
            item.useStyle = 1;
            item.knockBack = kb;
            item.value = value;
            item.rare = rarity;
            item.autoReuse = true;
        }
    }
}
