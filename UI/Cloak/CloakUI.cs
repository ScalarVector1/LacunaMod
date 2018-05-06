using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using System;
using Terraria.ID;
using System.Linq;

namespace LacunaMod.UI.Cloak
{
    class CloakUI : UIState
    {
        public UIPanel UIPanelC;
        public UIDisplay UIDisplayC;
        public static bool visible = false;

        public override void OnInitialize()
        {
            UIDisplayC = new UIDisplay();
            UIDisplayC.Left.Set(15, 0f);
            UIDisplayC.Top.Set(20, 0f);
            UIDisplayC.Width.Set(25f, 0f);
            UIDisplayC.Height.Set(39, 1f);
            UIPanelC.Append(UIDisplayC);
            UIDisplayC.OnMouseDown += new UIElement.MouseEvent(DragStart);
            UIDisplayC.OnMouseUp += new UIElement.MouseEvent(DragEnd);

            base.Append(UIPanelC);
        }

        Vector2 offset;
        public bool dragging = false;
        private void DragStart(UIMouseEvent evt, UIElement listeningElement)
        {
            offset = new Vector2(evt.MousePosition.X - UIPanelC.Left.Pixels, evt.MousePosition.Y - UIPanelC.Top.Pixels);
            dragging = true;
        }

        private void DragEnd(UIMouseEvent evt, UIElement listeningElement)
        {
            Vector2 end = evt.MousePosition;
            dragging = false;

            UIPanelC.Left.Set(end.X - offset.X, 0f);
            UIPanelC.Top.Set(end.Y - offset.Y, 0f);

            Recalculate();
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            Vector2 MousePosition = new Vector2((float)Main.mouseX, (float)Main.mouseY);
            if (UIPanelC.ContainsPoint(MousePosition))
            {
                Main.LocalPlayer.mouseInterface = true;
            }
            if (dragging)
            {
                UIPanelC.Left.Set(MousePosition.X - offset.X, 0f);
                UIPanelC.Top.Set(MousePosition.Y - offset.Y, 0f);
                Recalculate();
            }
        }
    }

    public class UIDisplay : UIElement
    {
        public UIDisplay()
        {
            Width.Set(25, 0f);
            Height.Set(39, 0f);
        }
        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            CalculatedStyle innerDimensions = base.GetInnerDimensions();
            Vector2 drawPos = new Vector2(innerDimensions.X + 5f, innerDimensions.Y + 30f);
            Texture2D CloakTexture = ModLoader.GetTexture("LacunaMod/UI/CloakUI/Cloak");

            float shopx = innerDimensions.X;
            float shopy = innerDimensions.Y;

            spriteBatch.Draw(CloakTexture, new Vector2(shopx + 11f, shopy), null, Color.White, 0f, CloakTexture.Size() / 2f, 1f, SpriteEffects.None, 0f);
        }
    }
}