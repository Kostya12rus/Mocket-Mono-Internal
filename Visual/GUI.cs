using EFT;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Mocket
{
    public partial class Main : MonoBehaviour
    {
        // The In-Game GUI Menu

        public void GUIMenu()
        {
            try
            {
                Menu.r = mr;
                Menu.g = mg;
                Menu.b = mb;
                Menu.a = ma;
                GUI.color = Menu;
                GUI.Box(new Rect(100f, 70f, 500f, 500f), "Mocket Version 0.9.9.5");
                this._showPlayerESP = GUI.Toggle(new Rect(110f, 140f, 120f, 20f), this._showPlayerESP, "  Player ESP");
                this._showExtractionESP = GUI.Toggle(new Rect(110f, 200f, 120f, 20f), this._showExtractionESP, "  Extraction ESP");
                this._showLootESP = GUI.Toggle(new Rect(110f, 220f, 120f, 20f), this._showLootESP, "  Loot ESP:" + Convert.ToInt32(ItemRenderDist));
                this.ItemRenderDist = GUI.HorizontalSlider(new Rect(110f, 240f, 120f, 20f), this.ItemRenderDist, 1.0F, 2500);
                GUI.Label(new Rect(110f, 260f, 120f, 100f), "Custom Item");
                this._customItem = GUI.TextField(new Rect(110f, 280f, 120f, 20f), this._customItem);
                this._noRecoil = GUI.Toggle(new Rect(110f, 300f, 120f, 20f), this._noRecoil, "  No-Recoil");
                this._wallBang = GUI.Toggle(new Rect(110f, 320f, 120f, 20f), this._wallBang, "  Wall Bang");
                this._fastloading = GUI.Toggle(new Rect(110f, 340f, 120f, 20f), this._fastloading, "  Fast Mags");
                this._superBullet = GUI.Toggle(new Rect(110f, 360f, 120f, 20f), this._superBullet, "  Super Bullet");
                this._fullbright = GUI.Toggle(new Rect(110f, 380f, 120f, 20f), this._fullbright, "  Fullbright");
                this._Speed = GUI.Toggle(new Rect(110f, 400f, 120f, 20f), this._Speed, "  Speed:" + Convert.ToInt32(speedSliderValue));
                this.speedSliderValue = GUI.HorizontalSlider(new Rect(110f, 420f, 120f, 20f), this.speedSliderValue, 1.0F, 10.0F);
                if (GUI.Button(new Rect(110f, 440f, 120f, 20f), "Day"))
                {
                    Day();
                }
                if (GUI.Button(new Rect(110f, 465f, 120f, 20f), "Aimbot Settings"))
                {
                    this.aimTab = !aimTab;
                }
                if (aimTab)
                {
                    if (colorsTab)
                    {
                        colorsTab = false;
                    }
                    GUI.Box(new Rect(620, 70, 400, 120), "Aim Settings");
                    aimbot = GUI.Toggle(new Rect(640, 90, 100, 20), aimbot, "Aimbot");
                    GUI.Label(new Rect(640, 105, 120, 20), "FOV:" + Convert.ToInt32(aimFov));
                    aimFov = GUI.HorizontalSlider(new Rect(675, 130, 120, 20), aimFov, 1.0F, 60.0F);
                }
                if (GUI.Button(new Rect(110f, 490f, 120f, 20f), "Color Settings"))
                {
                    this.colorsTab = !colorsTab;
                }
                if (colorsTab)
                {
                    if (aimTab)
                    {
                        aimTab = false;
                    }
                    GUI.Box(new Rect(0, 550, 400, 150), "Colors");
                    BearColor = GUI.Toggle(new Rect(20, 570, 100, 20), BearColor, "Bear");
                    USECColor = GUI.Toggle(new Rect(20, 590, 100, 20), USECColor, "USEC");
                    ScavColor = GUI.Toggle(new Rect(20, 610, 100, 20), ScavColor, "Scav");
                    CrosshairColor = GUI.Toggle(new Rect(20, 630, 100, 20), CrosshairColor, "Crosshair");
                    MenuColor = GUI.Toggle(new Rect(20, 650, 100, 20), MenuColor, "Menu");
                    if (CrosshairColor)
                    {
                        GUI.Box(new Rect(420, 550, 400, 150), "Crosshair Color");
                        GUI.Label(new Rect(440, 570, 100, 20), "Red:");
                        cr = GUI.HorizontalSlider(new Rect(440, 590, 100, 20), cr, 0.0F, 1.0F);
                        GUI.Label(new Rect(440, 610, 100, 20), "Green:");
                        cg = GUI.HorizontalSlider(new Rect(440, 630, 100, 20), cg, 0.0F, 1.0F);
                        GUI.Label(new Rect(440, 650, 100, 20), "Blue:");
                        cb = GUI.HorizontalSlider(new Rect(440, 670, 100, 20), cb, 0.0F, 1.0F);
                    }
                    if (MenuColor)
                    {
                        GUI.Box(new Rect(900, 550, 300, 150), "Menu Color");
                        GUI.Label(new Rect(920, 570, 100, 30), "Red:");
                        mr = GUI.HorizontalSlider(new Rect(920, 590, 100, 30), mr, 0.0F, 1.0F);
                        GUI.Label(new Rect(920, 610, 100, 30), "Green:");
                        mg = GUI.HorizontalSlider(new Rect(920, 630, 100, 30), mg, 0.0F, 1.0F);
                        GUI.Label(new Rect(920, 650, 100, 30), "Blue:");
                        mb = GUI.HorizontalSlider(new Rect(920, 670, 100, 30), mb, 0.0F, 1.0F);
                    }
                    if (USECColor)
                    {
                        GUI.Box(new Rect(820, 0, 300, 150), "USEC Color");
                        GUI.Label(new Rect(840, 15, 100, 20), "Red:");
                        rm = GUI.HorizontalSlider(new Rect(830, 30, 100, 20), rm, 0.0F, 1.0F);
                        GUI.Label(new Rect(840, 35, 100, 20), "Green:");
                        gm = GUI.HorizontalSlider(new Rect(830, 50, 100, 20), gm, 0.0F, 1.0F);
                        GUI.Label(new Rect(840, 55, 100, 20), "Blue:");
                        bm = GUI.HorizontalSlider(new Rect(830, 70, 100, 20), bm, 0.0F, 1.0F);
                    }
                    if (ScavColor)
                    {
                        GUI.Box(new Rect(1230, 0, 300, 150), "Scav Color");
                        GUI.Label(new Rect(1250, 15, 100, 20), "Red:");
                        rs = GUI.HorizontalSlider(new Rect(1240, 30, 100, 20), rs, 0.0F, 1.0F);
                        GUI.Label(new Rect(1250, 35, 100, 20), "Green:");
                        gs = GUI.HorizontalSlider(new Rect(1240, 50, 100, 20), gs, 0.0F, 1.0F);
                        GUI.Label(new Rect(1250, 55, 100, 20), "Blue:");
                        bs = GUI.HorizontalSlider(new Rect(1240, 70, 100, 20), bs, 0.0F, 1.0F);
                    }
                    if (BearColor)
                    {
                        GUI.Box(new Rect(1620, 0, 300, 150), "Bear Color");
                        GUI.Label(new Rect(1640, 15, 100, 20), "Red:");
                        r = GUI.HorizontalSlider(new Rect(1640, 30, 100, 20), r, 0.0F, 1.0F);
                        GUI.Label(new Rect(1640, 35, 100, 20), "Green:");
                        g = GUI.HorizontalSlider(new Rect(1640, 50, 100, 20), g, 0.0F, 1.0F);
                        GUI.Label(new Rect(1640, 55, 100, 20), "Blue:");
                        b = GUI.HorizontalSlider(new Rect(1640, 70, 100, 20), b, 0.0F, 1.0F);
                    }
                }
            }
            catch
            {
                File.WriteAllText("You are a cunt.txt", "Fuck you");
            }
        }
    }
}