using EFT;
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
        private void DrawPlayers()
        {
            foreach (Player player in GetGameWorld().RegisteredPlayers)
            {
                if (player == LocalPlayer) continue;
                if (!player.IsVisible) continue;

                #region Bone Vectors

                var playerRightPalmVector = new Vector3(
                    Camera.main.WorldToScreenPoint(player.PlayerBones.RightPalm.position).x,
                    Camera.main.WorldToScreenPoint(player.PlayerBones.RightPalm.position).y,
                    Camera.main.WorldToScreenPoint(player.PlayerBones.RightPalm.position).z);
                var playerLeftPalmVector = new Vector3(
                    Camera.main.WorldToScreenPoint(player.PlayerBones.LeftPalm.position).x,
                    Camera.main.WorldToScreenPoint(player.PlayerBones.LeftPalm.position).y,
                    Camera.main.WorldToScreenPoint(player.PlayerBones.LeftPalm.position).z);
                var playerLeftShoulderVector = new Vector3(
                    Camera.main.WorldToScreenPoint(player.PlayerBones.LeftShoulder.position).x,
                    Camera.main.WorldToScreenPoint(player.PlayerBones.LeftShoulder.position).y,
                    Camera.main.WorldToScreenPoint(player.PlayerBones.LeftShoulder.position).z);
                var playerRightShoulderVector = new Vector3(
                    Camera.main.WorldToScreenPoint(player.PlayerBones.RightShoulder.position).x,
                    Camera.main.WorldToScreenPoint(player.PlayerBones.RightShoulder.position).y,
                    Camera.main.WorldToScreenPoint(player.PlayerBones.RightShoulder.position).z);
                var playerNeckVector = new Vector3(
                    Camera.main.WorldToScreenPoint(player.PlayerBones.Neck.position).x,
                    Camera.main.WorldToScreenPoint(player.PlayerBones.Neck.position).y,
                    Camera.main.WorldToScreenPoint(player.PlayerBones.Neck.position).z);
                var playerCenterVector = new Vector3(
                    Camera.main.WorldToScreenPoint(player.PlayerBones.Pelvis.position).x,
                    Camera.main.WorldToScreenPoint(player.PlayerBones.Pelvis.position).y,
                    Camera.main.WorldToScreenPoint(player.PlayerBones.Pelvis.position).z);
                var playerRightThighVector = new Vector3(
                    Camera.main.WorldToScreenPoint(player.PlayerBones.RightThigh2.position).x,
                    Camera.main.WorldToScreenPoint(player.PlayerBones.RightThigh2.position).y,
                    Camera.main.WorldToScreenPoint(player.PlayerBones.RightThigh2.position).z);
                var playerLeftThighVector = new Vector3(
                    Camera.main.WorldToScreenPoint(player.PlayerBones.LeftThigh2.position).x,
                    Camera.main.WorldToScreenPoint(player.PlayerBones.LeftThigh2.position).y,
                    Camera.main.WorldToScreenPoint(player.PlayerBones.LeftThigh2.position).z);
                var playerRightFootVector = new Vector3(
                    Camera.main.WorldToScreenPoint(player.PlayerBones.KickingFoot.position).x,
                    Camera.main.WorldToScreenPoint(player.PlayerBones.KickingFoot.position).y,
                    Camera.main.WorldToScreenPoint(player.PlayerBones.KickingFoot.position).z);
                var playerBoundingVector = new Vector3(
                    Camera.main.WorldToScreenPoint(player.Transform.position).x,
                    Camera.main.WorldToScreenPoint(player.Transform.position).y,
                    Camera.main.WorldToScreenPoint(player.Transform.position).z);
                var playerHeadVector = new Vector3(
                    Camera.main.WorldToScreenPoint(player.PlayerBones.Head.position).x,
                    Camera.main.WorldToScreenPoint(player.PlayerBones.Head.position).y,
                    Camera.main.WorldToScreenPoint(player.PlayerBones.Head.position).z);
                var playerLeftFootVector = new Vector3(
                    Camera.main.WorldToScreenPoint(GetBonePosByID(player, 18)).x,
                    Camera.main.WorldToScreenPoint(GetBonePosByID(player, 18)).y,
                    Camera.main.WorldToScreenPoint(GetBonePosByID(player, 18)).z
                    );
                var playerLeftElbow = new Vector3(
                    Camera.main.WorldToScreenPoint(GetBonePosByID(player, 91)).x,
                    Camera.main.WorldToScreenPoint(GetBonePosByID(player, 91)).y,
                    Camera.main.WorldToScreenPoint(GetBonePosByID(player, 91)).z
                    );
                var playerRightElbow = new Vector3(
                    Camera.main.WorldToScreenPoint(GetBonePosByID(player, 112)).x,
                    Camera.main.WorldToScreenPoint(GetBonePosByID(player, 112)).y,
                    Camera.main.WorldToScreenPoint(GetBonePosByID(player, 112)).z
                    );
                var playerLeftKnee = new Vector3(
                    Camera.main.WorldToScreenPoint(GetBonePosByID(player, 17)).x,
                    Camera.main.WorldToScreenPoint(GetBonePosByID(player, 17)).y,
                    Camera.main.WorldToScreenPoint(GetBonePosByID(player, 17)).z
                    );
                var playerRightKnee = new Vector3(
                    Camera.main.WorldToScreenPoint(GetBonePosByID(player, 22)).x,
                    Camera.main.WorldToScreenPoint(GetBonePosByID(player, 22)).y,
                    Camera.main.WorldToScreenPoint(GetBonePosByID(player, 22)).z
                    );

                #endregion Bone Vectors

                Color playerColor = GetPlayerColor(player.Side, player);

                float distance = Vector3.Distance(Camera.main.transform.position, player.Transform.position);

                int sizeOfFont = 15;

                if (playerBoundingVector.z > 0.01)
                {
                    if (distance <= 50)
                    {
                        sizeOfFont = 15;
                    }
                    else if (distance < 100 && distance > 50)
                    { sizeOfFont = 13; }
                    else if (distance > 100 && distance <= 200)
                    { sizeOfFont = 11; }
                    else if (distance > 200 && distance <= 300)
                    { sizeOfFont = 9; }
                    else
                    { sizeOfFont = 9; }

                    var guistyle = new GUIStyle
                    { fontSize = sizeOfFont };

                    guistyle.normal.textColor = playerColor;

                    var isAi = player.Profile.Info.RegistrationDate <= 0;
                    int playerLevel = player.Profile.Info.Level;
                    var playerName = isAi ? "AI" : player.Profile.Info.Nickname;
                    float playerHealth = player.HealthController.imethod_0(EFT.HealthSystem.EBodyPart.Common).Current / 435f * 100f;
                    float headPos = Camera.main.WorldToScreenPoint(player.PlayerBones.Head.position).y + 30f;
                    string playerText = $"[{(int)playerHealth}%] {playerName} [{(int)distance}m] [{playerLevel}]";

                    #region Head Cross

                    H.Line(new Vector2(playerHeadVector.x - 2f, (float)Screen.height - playerHeadVector.y), new Vector2(playerHeadVector.x + 2f, (float)Screen.height - playerHeadVector.y), Color.cyan);
                    H.Line(new Vector2(playerHeadVector.x, (float)Screen.height - playerHeadVector.y - 2f), new Vector2(playerHeadVector.x, (float)Screen.height - playerHeadVector.y + 2f), Color.cyan);

                    #endregion Head Cross

                    #region Draw Text

                    var Style = GUI.skin.GetStyle(playerText).CalcSize(new GUIContent(playerText));
                    GUI.Label(new Rect(playerBoundingVector.x - Style.x / 2f, (float)Screen.height - headPos - 1, 300f, 50f), playerText, guistyle);

                    #endregion Draw Text

                    #region Draw Bones

                    H.Line(new Vector2(playerNeckVector.x, (float)Screen.height - playerNeckVector.y), new Vector2(playerCenterVector.x, (float)Screen.height - playerCenterVector.y), playerColor);
                    H.Line(new Vector2(playerLeftShoulderVector.x, (float)Screen.height - playerLeftShoulderVector.y), new Vector2(playerLeftElbow.x, (float)Screen.height - playerLeftElbow.y), playerColor);
                    H.Line(new Vector2(playerRightShoulderVector.x, (float)Screen.height - playerRightShoulderVector.y), new Vector2(playerRightElbow.x, (float)Screen.height - playerRightElbow.y), playerColor);
                    H.Line(new Vector2(playerLeftElbow.x, (float)Screen.height - playerLeftElbow.y), new Vector2(playerLeftPalmVector.x, (float)Screen.height - playerLeftPalmVector.y), playerColor);
                    H.Line(new Vector2(playerRightElbow.x, (float)Screen.height - playerRightElbow.y), new Vector2(playerRightPalmVector.x, (float)Screen.height - playerRightPalmVector.y), playerColor);
                    H.Line(new Vector2(playerRightShoulderVector.x, (float)Screen.height - playerRightShoulderVector.y), new Vector2(playerLeftShoulderVector.x, (float)Screen.height - playerLeftShoulderVector.y), playerColor);
                    H.Line(new Vector2(playerLeftKnee.x, (float)Screen.height - playerLeftKnee.y), new Vector2(playerCenterVector.x, (float)Screen.height - playerCenterVector.y), playerColor);
                    H.Line(new Vector2(playerRightKnee.x, (float)Screen.height - playerRightKnee.y), new Vector2(playerCenterVector.x, (float)Screen.height - playerCenterVector.y), playerColor);
                    H.Line(new Vector2(playerLeftKnee.x, (float)Screen.height - playerLeftKnee.y), new Vector2(playerLeftFootVector.x, (float)Screen.height - playerLeftFootVector.y), playerColor);
                    H.Line(new Vector2(playerRightKnee.x, (float)Screen.height - playerRightKnee.y), new Vector2(playerRightFootVector.x, (float)Screen.height - playerRightFootVector.y), playerColor);

                    #endregion Draw Bones
                }
            }
        }
    }
}