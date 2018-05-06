using System.Collections.Generic;
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

        //private UserInterface cloakUIprivate;
        //internal UI.Cloak.CloakUI cloakUIInternal;

        public static ModHotKey BoltKey;

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

            /*if (!Main.dedServ)
            {
                cloakUIInternal = new UI.Cloak.CloakUI();
                cloakUIInternal.Activate();
                cloakUIprivate = new UserInterface();
                cloakUIprivate.SetState(cloakUIInternal);
            }
        }
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int MouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (UI.Cloak.CloakUI.visible)
            {
                layers.Insert(MouseTextIndex, new LegacyGameInterfaceLayer(
                "LacunaMod: CloakUI",
                    delegate
                    {
                        if (UI.Cloak.CloakUI.visible)
                        {
                            cloakUIInternal.Draw(Main.spriteBatch);
                        }
                        return true;
                    },
                InterfaceScaleType.UI));
            }*/

            BoltKey = RegisterHotKey("Bolt Smash", "Z");

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
        public override void Unload()
        {
            CloakKey = null;
            BoltKey = null;
        }
    }
}
