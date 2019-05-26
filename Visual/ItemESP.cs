using EFT.InventoryLogic;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Mocket
{
    public partial class Main : MonoBehaviour
    {

        private string ItemNametoSimpleName(string id)
        {
            if (id.Contains("gphone"))
                return "GPhone";
            else if (id.Contains("bitcoin"))
                return "Bitcoin";
            else if (id.Contains("rolex"))
                return "Roler";
            else if (id.Contains("lion"))
                return "Lion";
            else if (id.Contains("clock"))
                return "Clock";
            else if (id.Contains("chain_gold"))
                return "Gold Chain";
            else if (id.Contains("wallet"))
                return "Wallet";
            else if (id.Contains("cpu"))
                return "CPU";
            else if (id.Contains("video"))
                return "Graphics Card";
            else if (id.Contains("insulation"))
                return "Tape";
            else if (id.Contains("apollo"))
                return "Apollo";
            else if (id.Contains("wilston"))
                return "Wilston";
            else if (id.Contains("malbor"))
                return "Malboro";
            else if (id.Contains("strike"))
                return "Strike";
            else if (id.Contains("powder"))
                return "Gun Powder";
            else if (id.Contains("battery_d"))
                return "D Battery";
            else if (id.Contains("crickent"))
                return "Crickent";
            else if (id.Contains("splint"))
                return "Splint";
            else if (id.Contains("wiper"))
                return "Wiper";
            else if (id.Contains("matches"))
                return "Matches";
            else if (id.Contains("analg"))
                return "Painkillers";
            else if (id.Contains("screw_bol"))
                return "Bolts";
            else if (id.Contains("Roulette"))
                return "MTape";
            else if (id.Contains("condensed"))
                return "Condensed Milk";
            else if (id.Contains("maxEnergy"))
                return "Energy Drink";
            else if (id.Contains("bandage"))
                return "Bandage";
            else if (id.Contains("screwdriver"))
                return "Screwdriver";
            else if (id.Contains("powerbank"))
                return "Power Bank";
            else if (id.Contains("ironkey"))
                return "Flashdrive";
            else if (id.Contains("item_barter_tools_pliers_elite"))
                return "Elite Pliers";
            else if (id.Contains("item_tools_pliers"))
                return "Pliers";
            else
                return id;

        }

        // Item ESP

        private void ShowItemESP()
        {
            try
            {
                foreach (LootItem lootItem in GetGameWorld().LootList)
                {

                    float num = Vector3.Distance(Camera.main.transform.position, lootItem.transform.position);
                    Vector3 vector = new Vector3(Camera.main.WorldToScreenPoint(lootItem.transform.position).x, Camera.main.WorldToScreenPoint(lootItem.transform.position).y, Camera.main.WorldToScreenPoint(lootItem.transform.position).z);
                    if ((double)vector.z > 0.01 && num <= ItemRenderDist && (lootItem.name.Contains("phone") || lootItem.name.Contains("lion") || lootItem.name.Contains("clock") || lootItem.name.Contains(_customItem) || lootItem.name.Contains("sv-98") && lootItem.name.Contains("container") || lootItem.name.Contains("sv98") || lootItem.name.Contains("chain_gold") || lootItem.name.Contains("bitcoin") || lootItem.name.Contains("dvl") && lootItem.name.Contains("container") || lootItem.name.Contains("m4a1") && lootItem.name.Contains("container") || lootItem.name.Contains("roler") || lootItem.name.Contains("wallet") || lootItem.name.Contains("RSASS") && lootItem.name.Contains("container") || lootItem.name.Contains("cpu") || lootItem.name.Contains("SA-58") && lootItem.name.Contains("container")) && (double)vector.z > 0.01)
                    {
                        int num2 = (int)num;
                        string arg;
                        try
                        {
                            arg = ItemNametoSimpleName(lootItem.name);
                        }
                        catch
                        {
                            arg = "error";
                        }
                        GUIStyle guistyle = new GUIStyle
                        {
                            fontSize = 15
                        };
                        guistyle.normal.textColor = Color.yellow;
                        string text = string.Format("{0} - {1}m", arg, num2);
                        GUI.Label(new Rect(vector.x - 50f, (float)Screen.height - vector.y, 100f, 50f), text, guistyle);
                    }
                }
            }
            catch
            {
            }
        }


    }
}