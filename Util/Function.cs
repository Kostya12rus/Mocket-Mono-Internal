using EFT;
using Comfort.Common;
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
        private GameWorld GetGameWorld()
        {
            if (Singleton<GameWorld>.Instantiated)
            {
                _PlayerCount = Singleton<GameWorld>.Instance.RegisteredPlayers.Count;
                foreach (Player player in Singleton<GameWorld>.Instance.RegisteredPlayers)
                {
                    if (player.gameObject.GetComponent<PlayerOwner>() != null)
                    {
                        LocalPlayer = player;
                    }
                }
                return Singleton<GameWorld>.Instance;
            }
            else
            {
                _PlayerCount = 0;
                _LightCreated = false;
                return null;
            }
        }

        private Color GetPlayerColor(EPlayerSide side, Player player)
        {
            Bear.r = r;
            Bear.g = g;
            Bear.b = b;
            Bear.a = 1;
            USEC.r = rm;
            USEC.g = gm;
            USEC.b = bm;
            USEC.a = 1;
            Scav.r = rs;
            Scav.g = gs;
            Scav.b = bs;
            Scav.a = 1;
            if (IsVisible(player.gameObject, getBonePos(player)))
            {
                return Color.magenta;
            }
            else
            {
                switch (side)
                {
                    case EPlayerSide.Bear:
                        return Bear;

                    case EPlayerSide.Usec:
                        return USEC;

                    case EPlayerSide.Savage:
                        return Scav;

                    default:
                        return Color.white;
                }
            }
        }
    }
}