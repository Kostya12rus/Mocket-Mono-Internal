using UnityEngine;

namespace Mocket
{
    public partial class Main : MonoBehaviour
    {

        private string extractionNametoSimpleName(string extractionName)
        {
            // Factory
            if (extractionName.Contains("exit (3)"))
                return "Cellars";
            else if (extractionName.Contains("exit (1)"))
                return "Gate 3";
            else if (extractionName.Contains("exit (2)"))
                return "Gate 0";
            else if (extractionName.Contains("exit_scav_gate3"))
                return "Gate 3";
            else if (extractionName.Contains("exit_scav_camer"))
                return "Blinking Light";
            else if (extractionName.Contains("exit_scav_office"))
                return "Office";

            // Woods
            else if (extractionName.Contains("eastg"))
                return "East Gate";
            else if (extractionName.Contains("scavh"))
                return "House";
            else if (extractionName.Contains("deads"))
                return "Dead Mans Place";
            else if (extractionName.Contains("var1_1_constant"))
                return "Outskirts";
            else if (extractionName.Contains("scav_outskirts"))
                return "Outskirts";
            else if (extractionName.Contains("water"))
                return "Outskirts Water";
            else if (extractionName.Contains("boat"))
                return "The Boat";
            else if (extractionName.Contains("mountain"))
                return "Mountain Stash";
            else if (extractionName.Contains("oldstation"))
                return "Old Station";
            else if (extractionName.Contains("UNroad"))
                return "UN Road Block";
            else if (extractionName.Contains("var2_1_const"))
                return "UN Road Block";
            else if (extractionName.Contains("gatetofactory"))
                return "Gate to Factory";
            else if (extractionName.Contains("RUAF"))
                return "RUAF Gate";

            // Shoreline
            else if (extractionName.Contains("roadtoc"))
                return "Road to Customs";
            else if (extractionName.Contains("lighthouse"))
                return "Lighthouse";
            else if (extractionName.Contains("tunnel"))
                return "Tunnel";
            else if (extractionName.Contains("wreckedr"))
                return "Wrecked Road";
            else if (extractionName.Contains("deadend"))
                return "Dead End";
            else if (extractionName.Contains("housefence"))
                return "Ruined House Fence";
            else if (extractionName.Contains("gyment"))
                return "Gym Entrance";
            else if (extractionName.Contains("southfence"))
                return "South Fence Passage";
            else if (extractionName.Contains("adm_base"))
                return "Admin Basement";

            // Customs
            else if (extractionName.Contains("administrationg"))
                return "Administration Gate";
            else if (extractionName.Contains("factoryfar"))
                return "Factory Far Corner";
            else if (extractionName.Contains("oldazs"))
                return "Old Gate";
            else if (extractionName.Contains("milkp_sh"))
                return "Shack";
            else if (extractionName.Contains("beyondfuel"))
                return "Beyond Fuel Tank";
            else if (extractionName.Contains("railroadtom"))
                return "Railroad to Mil Base";
            else if (extractionName.Contains("_pay_car"))
                return "V-Exit";
            else if (extractionName.Contains("oldroadgate"))
                return "Old Road Gate";
            else if (extractionName.Contains("sniperroad"))
                return "Sniper Road Block";
            else if (extractionName.Contains("warehouse17"))
                return "Warehouse 17";
            else if (extractionName.Contains("factoryshacks"))
                return "Factory Shacks";
            else if (extractionName.Contains("railroadtotarkov"))
                return "Railroad to Tarkov";
            else if (extractionName.Contains("trailerpark"))
                return "Trailer Park";
            else if (extractionName.Contains("crossroads"))
                return "Crossroads";
            else if (extractionName.Contains("railroadtoport"))
                return "Railroad to Port";

            // Interchange
            else if (extractionName.Contains("NW_Exfil"))
                return "North West Extract";
            else if (extractionName.Contains("SE_Exfil"))
                return "South East Extract";
            else
                return extractionName;
        }

        public void ExtractionESP()
        {
            foreach (var point in _extractPoints)
            {
                if (point != null)
                {
                    float distanceToObject = Vector3.Distance(Camera.main.transform.position, point.transform.position);
                    var exfilContainerBoundingVector = new Vector3(
                        Camera.main.WorldToScreenPoint(point.transform.position).x,
                        Camera.main.WorldToScreenPoint(point.transform.position).y,
                        Camera.main.WorldToScreenPoint(point.transform.position).z);

                    if (exfilContainerBoundingVector.z > 0.01)
                    {
                        GUI.color = Color.green;
                        int distance = (int)distanceToObject;
                        string extractionName = point.name;
                        string extractionSimpleName = extractionNametoSimpleName(extractionName);
                        string boxText = $"{extractionSimpleName} - {distance}m";

                        GUI.Label(new Rect(exfilContainerBoundingVector.x - 50f, (float)Screen.height - exfilContainerBoundingVector.y, 100f, 50f), boxText);
                    }
                }
            }
        }
    }
}