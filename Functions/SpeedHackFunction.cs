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
        public void Speed_Method()
        {
            if (Input.GetMouseButton(3))
            {
                Time.timeScale = speedSliderValue;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }
}
