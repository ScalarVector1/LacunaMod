using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using System;
using Terraria.ID;
using System.Linq;

namespace LacunaMod.UI.Upgrades
{
    class UpgradeUI : UIState
    {
        public UIElement UpgradePanel;
        public static bool visible = true;
        static Texture2D CloakMeterLockedTexture = ModLoader.GetTexture("LacunaMod/UI/Upgrades/Cloak/Cloak_2");
        static Texture2D CloakMeterBlackTexture = ModLoader.GetTexture("LacunaMod/UI/Upgrades/Cloak/Cloak_1");
        static Texture2D CloakMeterChargeTexture = ModLoader.GetTexture("LacunaMod/UI/Upgrades/Cloak/Cloak_0");
        static Texture2D CloakMeterFullTexture = ModLoader.GetTexture("LacunaMod/UI/Upgrades/Cloak/Cloak_3");
        UIImage CloakMeter = new UIImage(CloakMeterChargeTexture);

        public override void OnInitialize()
        {
            UpgradePanel = new UIElement();
            UpgradePanel.SetPadding(0);
            UpgradePanel.Left.Set(400f, 0f);
            UpgradePanel.Top.Set(100f, 0f);
            UpgradePanel.Width.Set(34f, 0f);
            UpgradePanel.Height.Set(100f, 0f);

            UpgradePanel.OnMouseDown += new UIElement.MouseEvent(DragStart);
            UpgradePanel.OnMouseUp += new UIElement.MouseEvent(DragEnd);

            UIImage CloakMeterBack = new UIImage(CloakMeterLockedTexture);
            CloakMeterBack.Left.Set(2, 0f);
            CloakMeterBack.Top.Set(2, 0f);
            CloakMeterBack.Width.Set(30, 0f);
            CloakMeterBack.Height.Set(44, 0f);
            UpgradePanel.Append(CloakMeterBack);

            CloakMeter.Left.Set(2, 0f);
            CloakMeter.Top.Set(2, 0f);
            CloakMeter.Width.Set(30, 0f);
            CloakMeter.Height.Set(44, 0f);
            UpgradePanel.Append(CloakMeter);

            base.Append(UpgradePanel);
        }

        Vector2 offset;
        public bool dragging = false;
        
        private void DragStart(UIMouseEvent evt, UIElement listeningElement)
        {
            offset = new Vector2(evt.MousePosition.X - UpgradePanel.Left.Pixels, evt.MousePosition.Y - UpgradePanel.Top.Pixels);
            dragging = true;
        }

        private void DragEnd(UIMouseEvent evt, UIElement listeningElement)
        {
            Vector2 end = evt.MousePosition;
            dragging = false;

            UpgradePanel.Left.Set(end.X - offset.X, 0f);
            UpgradePanel.Top.Set(end.Y - offset.Y, 0f);

            Recalculate();
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            Vector2 MousePosition = new Vector2((float)Main.mouseX, (float)Main.mouseY);

            if (Main.LocalPlayer.GetModPlayer<LCPlr>().teletimer == 0 && Main.LocalPlayer.GetModPlayer<LCPlr>().TeleCloak == true)
            {
                CloakMeter.SetImage(CloakMeterFullTexture);
            }
            if (UpgradePanel.ContainsPoint(MousePosition))
            {
                Main.LocalPlayer.mouseInterface = true;
            }
            if (dragging)
            {
                UpgradePanel.Left.Set(MousePosition.X - offset.X, 0f);
                UpgradePanel.Top.Set(MousePosition.Y - offset.Y, 0f);
                Recalculate();
            }

        }
    }
}