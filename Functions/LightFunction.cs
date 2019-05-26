using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Mocket
{
    partial class Main
    {
        public void Fullbright()
        {
            if (!lightCalled)
            {
                lightGameObject = new GameObject("Fullbright");
                FullBrightLight = lightGameObject.AddComponent<Light>();
                FullBrightLight.color = Color.white;
                lightCalled = true;
            }
        }
    }
}
