using System.Collections.Generic;
using LacunaMod.UI.Upgrades;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;

namespace LacunaMod
{
    class LacunaMod : Mod
	{
        public static ModHotKey CloakKey;
        public static ModHotKey BoltKey;
        private UserInterface exampleUserInterface;
        internal UpgradeUI exampleUI;
        public static ModHotKey FlyKey;

        public LacunaMod()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};
		}
        public override void Load()
        {
            CloakKey = RegisterHotKey("Cloak Teleport", "Q");
            BoltKey = RegisterHotKey("Bolt Smash", "Z");
            if (!Main.dedServ)
            {
                exampleUI = new UpgradeUI();
                exampleUI.Activate();
                exampleUserInterface = new UserInterface();
                exampleUserInterface.SetState(exampleUI);
            }
            FlyKey = RegisterHotKey("Toggle Zephyr Glide", "N");
        }

        public override void AddRecipeGroups()
        {
            // Gems
            RecipeGroup group = new RecipeGroup(() => Lang.misc[37] + " gem", new int[]
            {
                    ItemID.Ruby,
                    ItemID.Topaz,
                    ItemID.Diamond,
                    ItemID.Sapphire,
                    ItemID.Emerald,
                    ItemID.Amethyst
            });
            RecipeGroup.RegisterGroup("Gems", group);

            // Hermes Boots Variants
            group = new RecipeGroup(() => Lang.misc[37] + " hermes boots", new int[]
            {
                    ItemID.FlurryBoots,
                    ItemID.HermesBoots,
                    ItemID.SailfishBoots
            });
            RecipeGroup.RegisterGroup("Speed Boots", group);
        }
        public override void UpdateUI(GameTime gameTime)
        {
            if (exampleUserInterface != null && UpgradeUI.visible)
                exampleUserInterface.Update(gameTime);
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int MouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (MouseTextIndex != -1)
            {
                layers.Insert(MouseTextIndex, new LegacyGameInterfaceLayer(
                    "LacunaMod: Upgrade Charge",
                    delegate
                    {
                        if (UpgradeUI.visible)
                        {
                            exampleUI.Draw(Main.spriteBatch);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
        }
        public override void Unload()
        {
            CloakKey = null;
            BoltKey = null;
            FlyKey = null;
        }
    }
}
