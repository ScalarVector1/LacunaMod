using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using System;

namespace LacunaMod.UI
{
    class CloakUI : UIState
    {
        public UIPanel Cloak;
        public static bool visible = true;
        Texture2D CloakTexture = ModLoader.GetTexture("Lacunamod/Items/KeyItems/Cloak");

        public override void OnInitialize()
        {
            UIPanel CloakPanel = new UIPanel();
            CloakPanel.Height.Set(65f, 0f);
            CloakPanel.Width.Set(300f, 0f);
            CloakPanel.Left.Set(Main.screenWidth - CloakPanel.Width.Pixels, 0f);
            CloakPanel.Top.Set(0f, 0f);
        }
        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            CalculatedStyle dimensions = GetDimensions();
            Point point1 = new Point((int)dimensions.X, (int)dimensions.Y);
            int width = (int)Math.Ceiling(dimensions.Width);
            int height = (int)Math.Ceiling(dimensions.Height);
            spriteBatch.Draw(CloakTexture, new Rectangle(point1.X, point1.Y, width, height), Color.Gray);
        }
    }
}