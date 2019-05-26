using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using EFT;

namespace Mocket
{
    partial class Main
    {
        public IEnumerable<Door> _doors;
        public IEnumerable<ExfiltrationPoint> _extractPoints;
        public GameObject GameObjectHolder;
        public GameObject lightGameObject;
        public Light FullBrightLight;

        private static Player LocalPlayer;

        public string _customItem = "";
        public string HWID;
        public string username;

        public Vector3 playerPos;

        public float _PlayerCount;
        public float _playersNextUpdateTime;
        public float _itemsNextUpdateTime;
        public float _ExtractionNextUpdateTime;
        public float speedSliderValue = 5.0F;
        public float _espUpdateInterval = 100f;
        public float _playerEspUpdateInterval = 2f;
        public float aimFov = 10;
        public float closestPlayer;
        public float ItemRenderDist = 50f;
        public float _maxDrawingDistance = 1500f;

        public bool _LightEnabled = true;
        public bool _LightCreated;
        public bool _showPlayerESP = true;
        public bool _superBullet = true;
        public bool _BodyESP = true;
        public bool _fastloading = true;
        public bool _thirdPerson;
        public bool _wallBang;
        public bool _isGUIOpen;
        public bool aimTab;
        public bool _Speed = true;
        public bool _showScavESP = true;
        public bool _showLootESP;
        public bool _showExtractionESP;
        public bool _noRecoil = true;
        public bool aimbot = true;
        public bool playerESPAlive;
        public bool isInGame = false;
        public bool _fullbright;
        public bool lightCalled;
        public bool colorsTab;
        public bool Pov;

        // RGB Shit
        public float rs = 1;

        public float gs = 1;
        public float bs = 1;
        public float rm = 0;
        public float gm = 0;
        public float bm = 1;
        public float cr = 0;
        public float cg = 1;
        public float cb = 1;
        public float ca = 1;
        public float dr = 1f;
        public float dg = 0.5f;
        public float db = 0.1f;
        public float da = 1f;
        public float mr = 1f;
        public float mg = 1f;
        public float mb = 1f;
        public float ma = 1f;
        public float r = 1;
        public float g = 0;
        public float b = 0;

        public Color USEC;
        public Color Bear;
        public Color Scav;
        public Color Crosshair;
        public Color Menu = Color.white;

        public bool USECColor = false;
        public bool BearColor = false;
        public bool ScavColor = false;
        public bool CrosshairColor = false;
        public bool MenuColor = false;
    }
}