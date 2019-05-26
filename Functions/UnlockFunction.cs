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
        private void Unlock_Method()
        {
            if (Input.GetKeyDown(KeyCode.End))
            {
                IEnumerable<Door> doors = FindObjectsOfType<Door>();
                foreach (Door door in doors)
                {
                    door.enabled = true;
                    door.DoorState = EDoorState.Shut;
                }
                IEnumerable<LootableContainer> containers = FindObjectsOfType<LootableContainer>();
                foreach (LootableContainer lootableContainer in containers)
                {
                    lootableContainer.enabled = true;
                    lootableContainer.DoorState = EDoorState.Shut;
                }
            }
        }
    }
}