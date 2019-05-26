using Comfort.Common;
using EFT;
using System;
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Linq;

namespace Mocket
{
    public partial class Main : MonoBehaviour
    {
        #region Load Unload

        public void Load()
        {
            GameObjectHolder = new GameObject();
            GameObjectHolder.AddComponent<Main>();
            DontDestroyOnLoad(GameObjectHolder);
        }

        public void UnLoad()
        {
        }

        public Main()
        {
        }

        #endregion Load Unload

        #region Update

        public void Update()
        {
            try
            {
                #region Teleport

                Teleport_Method();

                #endregion Teleport

                #region Aimbot

                if (Input.GetKey(KeyCode.LeftAlt) && aimbot)
                {
                    foreach (Player ply in Singleton<GameWorld>.Instance.RegisteredPlayers)
                    {
                        if (ply.PointOfView == EPointOfView.FirstPerson)
                        {
                            LocalPlayer = ply;
                        }
                    }
                    Aimbot_Method();
                }

                #endregion Aimbot

                #region GUI

                if (Input.GetKeyDown(KeyCode.Insert))
                {
                    this._isGUIOpen = !_isGUIOpen;
                }

                #endregion GUI

                #region Unlock Doors

                if (Input.GetKeyDown(KeyCode.End))
                {
                    this.Unlock_Method();
                }

                #endregion Unlock Doors

                #region POV Key

                if (Input.GetKeyDown(KeyCode.K))
                {
                    Pov = !Pov;
                    foreach (Player player in Singleton<GameWorld>.Instance.RegisteredPlayers)
                    {
                        if (Pov)
                        {
                            LocalPlayer.PointOfView = EPointOfView.ThirdPerson;
                        }
                        if (!Pov)
                        {
                            LocalPlayer.PointOfView = EPointOfView.FirstPerson;
                        }
                    }
                }

                #endregion POV Key

                #region Speed Hack

                if (_Speed)
                {
                    Speed_Method();
                }

                #endregion Speed Hack

                #region Fullbright

                if (_fullbright)
                {
                    playerPos = new Vector3(
                        LocalPlayer.Transform.position.x,
                        LocalPlayer.Transform.position.y + 1,
                        LocalPlayer.Transform.position.z);
                    lightGameObject.transform.position = playerPos;
                    FullBrightLight.range = 1000;
                }
                else
                {
                    GameObject.Destroy(FullBrightLight);
                    lightCalled = false;
                }

                #endregion Fullbright
            }
            catch
            {
            }
        }

        #endregion Update

        #region OnGUI

        private void OnGUI()
        {
            try
            {
                #region Crossy

                if (GetGameWorld())
                {
                    Crosshair.r = cr;
                    Crosshair.g = cg;
                    Crosshair.b = cb;
                    Crosshair.a = ca;
                    H.Box((float)Screen.width / 2f, (float)Screen.height / 2f - 5f, 1f, 11f, Crosshair);
                    H.Box((float)Screen.width / 2f - 5f, (float)Screen.height / 2f, 11f, 1f, Crosshair);
                }

                #endregion Crossy

                #region Player Count

                if (GetGameWorld())
                {
                    GUIStyle playerCountStyle = new GUIStyle
                    {
                        fontSize = 15
                    };
                    playerCountStyle.normal.textColor = Color.white;

                    GUI.Label(new Rect(0, 0, 10f, 50f), $" Player Count: {_PlayerCount}", playerCountStyle);
                }

                #endregion Player Count

                #region Toggles

                if (this._isGUIOpen)
                {
                    this.GUIMenu();
                }
                if (this._showLootESP)
                {
                    if (Time.time >= this._itemsNextUpdateTime)
                    {
                        this._itemsNextUpdateTime = Time.time + this._espUpdateInterval;
                    }
                    this.ShowItemESP();
                }
                if (this._showPlayerESP)
                {
                    if (Time.time >= this._playersNextUpdateTime)
                    {
                        this._playersNextUpdateTime = Time.time + this._playerEspUpdateInterval;
                    }
                    DrawPlayers();
                }
                if (_showExtractionESP && Time.time >= _ExtractionNextUpdateTime)
                {
                    this._extractPoints = FindObjectsOfType<ExfiltrationPoint>();
                    this._ExtractionNextUpdateTime = Time.time + _espUpdateInterval;
                }
                if (this._noRecoil)
                {
                    this.NoRecoil();
                }
                if (this._wallBang)
                {
                    this.wallBang();
                }
                if (this._superBullet)
                {
                    this.superBullet();
                }
                if (this._showExtractionESP)
                {
                    this.ExtractionESP();
                }
                if (this._fullbright)
                {
                    Fullbright();
                }

                #endregion Toggles
            }
            catch
            {
            }
        }

        #endregion OnGUI
    }
}