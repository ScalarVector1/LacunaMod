using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;

using Terraria.UI;
using Terraria.DataStructures;
using Terraria.GameContent.UI;
using System;

namespace LacunaMod
{
	class LacunaMod : Mod
	{
        public static ModHotKey CloakKey;
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
            CloakKey = RegisterHotKey("Teleport", "P");
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
        }
    }
}
