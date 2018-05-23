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
        //Cloak textures
        static Texture2D CloakMeterLockedTexture = ModLoader.GetTexture("LacunaMod/UI/Upgrades/Cloak/Cloak_2");
        static Texture2D CloakMeterBlackTexture = ModLoader.GetTexture("LacunaMod/UI/Upgrades/Cloak/Cloak_1");
        static Texture2D CloakMeterChargeTexture = ModLoader.GetTexture("LacunaMod/UI/Upgrades/Cloak/Cloak_0");
        static Texture2D CloakMeterFullTexture = ModLoader.GetTexture("LacunaMod/UI/Upgrades/Cloak/Cloak_3");
        static Texture2D CloakMeter10 = ModLoader.GetTexture("LacunaMod/UI/Upgrades/Cloak/Cloak_10");
        static Texture2D CloakMeter20 = ModLoader.GetTexture("LacunaMod/UI/Upgrades/Cloak/Cloak_20");
        static Texture2D CloakMeter30 = ModLoader.GetTexture("LacunaMod/UI/Upgrades/Cloak/Cloak_30");
        static Texture2D CloakMeter40 = ModLoader.GetTexture("LacunaMod/UI/Upgrades/Cloak/Cloak_40");
        static Texture2D CloakMeter50 = ModLoader.GetTexture("LacunaMod/UI/Upgrades/Cloak/Cloak_50");
        static Texture2D CloakMeter60 = ModLoader.GetTexture("LacunaMod/UI/Upgrades/Cloak/Cloak_60");
        static Texture2D CloakMeter70 = ModLoader.GetTexture("LacunaMod/UI/Upgrades/Cloak/Cloak_70");
        static Texture2D CloakMeter80 = ModLoader.GetTexture("LacunaMod/UI/Upgrades/Cloak/Cloak_80");
        static Texture2D CloakMeter90 = ModLoader.GetTexture("LacunaMod/UI/Upgrades/Cloak/Cloak_90");
        //Bolt textures
        static Texture2D BoltMeterLocked = ModLoader.GetTexture("LacunaMod/UI/Upgrades/Bolt/Locked");
        static Texture2D BoltMeter0 = ModLoader.GetTexture("LacunaMod/UI/Upgrades/Bolt/0");
        static Texture2D BoltMeterFull = ModLoader.GetTexture("LacunaMod/UI/Upgrades/Bolt/Charged");
        static Texture2D BoltMeter20 = ModLoader.GetTexture("LacunaMod/UI/Upgrades/Bolt/20");
        static Texture2D BoltMeter40 = ModLoader.GetTexture("LacunaMod/UI/Upgrades/Bolt/40");
        static Texture2D BoltMeter60 = ModLoader.GetTexture("LacunaMod/UI/Upgrades/Bolt/60");
        static Texture2D BoltMeter80 = ModLoader.GetTexture("LacunaMod/UI/Upgrades/Bolt/80");
        static Texture2D BoltMeter100 = ModLoader.GetTexture("LacunaMod/UI/Upgrades/Bolt/100");


        UIImage CloakMeter = new UIImage(CloakMeterLockedTexture);
        UIImage BoltMeter = new UIImage(BoltMeterLocked);

        public override void OnInitialize()
        {
            UpgradePanel = new UIElement();
            UpgradePanel.SetPadding(0);
            UpgradePanel.Left.Set(400f, 0f);
            UpgradePanel.Top.Set(100f, 0f);
            UpgradePanel.Width.Set(34f, 0f);
            UpgradePanel.Height.Set(200f, 0f);

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

            UIImage BoltMeterBack = new UIImage(BoltMeterLocked);
            BoltMeterBack.Left.Set(4, 0f);
            BoltMeterBack.Top.Set(54, 0f);
            BoltMeterBack.Width.Set(24, 0f);
            BoltMeterBack.Height.Set(46, 0f);
            UpgradePanel.Append(BoltMeterBack);

            BoltMeter.Left.Set(4, 0f);
            BoltMeter.Top.Set(54, 0f);
            BoltMeter.Width.Set(24, 0f);
            BoltMeter.Height.Set(46, 0f);
            UpgradePanel.Append(BoltMeter);

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

            if (Main.LocalPlayer.GetModPlayer<LCPlr>().teletimer == 0 && Main.LocalPlayer.GetModPlayer<LCPlr>().TeleCloak == true) // if charged and unlocked
            {
                CloakMeter.SetImage(CloakMeterFullTexture);
            }
            else if (Main.LocalPlayer.GetModPlayer<LCPlr>().teletimer <= 270 && Main.LocalPlayer.GetModPlayer<LCPlr>().teletimer >= 240 && Main.LocalPlayer.GetModPlayer<LCPlr>().TeleCloak == true)//4.5 seconds left
            {
                CloakMeter.SetImage(CloakMeter10);
            }
            else if (Main.LocalPlayer.GetModPlayer<LCPlr>().teletimer <= 240 && Main.LocalPlayer.GetModPlayer<LCPlr>().teletimer >= 210 && Main.LocalPlayer.GetModPlayer<LCPlr>().TeleCloak == true)//4 seconds left
            {
                CloakMeter.SetImage(CloakMeter20);
            }
            else if (Main.LocalPlayer.GetModPlayer<LCPlr>().teletimer <= 210 && Main.LocalPlayer.GetModPlayer<LCPlr>().teletimer >= 180 && Main.LocalPlayer.GetModPlayer<LCPlr>().TeleCloak == true)//3.5 seconds left
            {
                CloakMeter.SetImage(CloakMeter30);
            }
            else if (Main.LocalPlayer.GetModPlayer<LCPlr>().teletimer <= 180 && Main.LocalPlayer.GetModPlayer<LCPlr>().teletimer >= 150 && Main.LocalPlayer.GetModPlayer<LCPlr>().TeleCloak == true)//3 seconds left
            {
                CloakMeter.SetImage(CloakMeter40);
            }
            else if (Main.LocalPlayer.GetModPlayer<LCPlr>().teletimer <= 150 && Main.LocalPlayer.GetModPlayer<LCPlr>().teletimer >= 120 && Main.LocalPlayer.GetModPlayer<LCPlr>().TeleCloak == true)//2.5 seconds left
            {
                CloakMeter.SetImage(CloakMeter50);
            }
            else if (Main.LocalPlayer.GetModPlayer<LCPlr>().teletimer <= 120 && Main.LocalPlayer.GetModPlayer<LCPlr>().teletimer >= 90 && Main.LocalPlayer.GetModPlayer<LCPlr>().TeleCloak == true)//2 seconds left
            {
                CloakMeter.SetImage(CloakMeter60);
            }
            else if (Main.LocalPlayer.GetModPlayer<LCPlr>().teletimer <= 90 && Main.LocalPlayer.GetModPlayer<LCPlr>().teletimer >= 60 && Main.LocalPlayer.GetModPlayer<LCPlr>().TeleCloak == true)//1.5 seconds left
            {
                CloakMeter.SetImage(CloakMeter70);
            }
            else if (Main.LocalPlayer.GetModPlayer<LCPlr>().teletimer <= 60 && Main.LocalPlayer.GetModPlayer<LCPlr>().teletimer >= 30 && Main.LocalPlayer.GetModPlayer<LCPlr>().TeleCloak == true)//1 second left
            {
                CloakMeter.SetImage(CloakMeter80);
            }
            else if (Main.LocalPlayer.GetModPlayer<LCPlr>().teletimer <= 30 && Main.LocalPlayer.GetModPlayer<LCPlr>().teletimer >= 0 && Main.LocalPlayer.GetModPlayer<LCPlr>().TeleCloak == true)//.5 second left
            {
                CloakMeter.SetImage(CloakMeter90);
            }
            else if (Main.LocalPlayer.GetModPlayer <LCPlr>().teletimer != 0 && Main.LocalPlayer.GetModPlayer<LCPlr>().TeleCloak == true)// if not charged and unlocked
            {
                CloakMeter.SetImage(CloakMeterBlackTexture);
            }
            else if (Main.LocalPlayer.GetModPlayer <LCPlr>().TeleCloak == false)// if locked
            {
                CloakMeter.SetImage(CloakMeterLockedTexture);
            }
            //Bolt
            if (Main.LocalPlayer.GetModPlayer<LCPlr>().bolttimer == 0 && Main.LocalPlayer.GetModPlayer<LCPlr>().Bolt == true) // if charged and unlocked
            {
                BoltMeter.SetImage(BoltMeterFull);
            }
            else if (Main.LocalPlayer.GetModPlayer<LCPlr>().bolttimer <= 150 && Main.LocalPlayer.GetModPlayer<LCPlr>().bolttimer >= 120 && Main.LocalPlayer.GetModPlayer<LCPlr>().Bolt == true)//2.5 seconds left
            {
                BoltMeter.SetImage(BoltMeter20);
            }
            else if (Main.LocalPlayer.GetModPlayer<LCPlr>().bolttimer <= 120 && Main.LocalPlayer.GetModPlayer<LCPlr>().bolttimer >= 90 && Main.LocalPlayer.GetModPlayer<LCPlr>().Bolt == true)//2 seconds left
            {
                BoltMeter.SetImage(BoltMeter40);
            }
            else if (Main.LocalPlayer.GetModPlayer<LCPlr>().bolttimer <= 90 && Main.LocalPlayer.GetModPlayer<LCPlr>().bolttimer >= 60 && Main.LocalPlayer.GetModPlayer<LCPlr>().Bolt == true)//1.5 seconds left
            {
                BoltMeter.SetImage(BoltMeter60);
            }
            else if (Main.LocalPlayer.GetModPlayer<LCPlr>().bolttimer <= 60 && Main.LocalPlayer.GetModPlayer<LCPlr>().bolttimer >= 30 && Main.LocalPlayer.GetModPlayer<LCPlr>().Bolt == true)//1 seconds left
            {
                BoltMeter.SetImage(BoltMeter80);
            }
            else if (Main.LocalPlayer.GetModPlayer<LCPlr>().bolttimer <= 30 && Main.LocalPlayer.GetModPlayer<LCPlr>().bolttimer >= 0 && Main.LocalPlayer.GetModPlayer<LCPlr>().Bolt == true)//2.5 seconds left
            {
                BoltMeter.SetImage(BoltMeter100);
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