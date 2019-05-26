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
        private void Teleport_Method()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                LocalPlayer.Transform.position += LocalPlayer.Transform.forward * 1;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                LocalPlayer.Transform.position += LocalPlayer.Transform.forward * -1;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                LocalPlayer.Transform.position += LocalPlayer.Transform.right * 1;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                LocalPlayer.Transform.position += LocalPlayer.Transform.right * -1;
            }
            if (Input.GetKeyDown(KeyCode.PageUp))
            {
                LocalPlayer.Transform.position += LocalPlayer.Transform.up * 1;
            }
            if (Input.GetKeyDown(KeyCode.PageDown))
            {
                LocalPlayer.Transform.position += LocalPlayer.Transform.up * -1;
            }
            if (Input.GetMouseButtonDown(2))
            {
                try
                {
                    Ray ray = Camera.main.ScreenPointToRay(Camera.main.transform.forward * 1f);
                    RaycastHit raycastHit;
                    if (Physics.Raycast(ray, out raycastHit))
                    {
                        LocalPlayer.vmethod_47(raycastHit.point, true);
                    }
                }
                catch
                {
                }
            }
        }
    }
}