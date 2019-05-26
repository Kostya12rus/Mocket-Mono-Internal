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
        public void Aimbot_Method()
        {
            foreach (Player player in GetGameWorld().RegisteredPlayers)
            {
                if (!(player == null) && !(player == LocalPlayer) && player.HealthController != null && player.HealthController.IsAlive)
                {
                    Vector3 vector = getBonePos(player);
                    if (!(vector == Vector3.zero) && CalcInFov(vector) <= aimFov && IsVisible(player.gameObject, getBonePos(player)))
                    {
                        AimAtPos(vector);
                    }
                }
            }
        }

        private bool IsVisible(GameObject obj, Vector3 Position)
        {
            RaycastHit raycastHit;
            return Physics.Linecast(GetShootPos(), Position, out raycastHit) && raycastHit.collider && raycastHit.collider.gameObject.transform.root.gameObject == obj.transform.root.gameObject;
        }

        public static Vector3 GetShootPos()
        {
            if (LocalPlayer == null)
            {
                return Vector3.zero;
            }
            Player.FirearmController firearmController = LocalPlayer.HandsController as Player.FirearmController;
            if (firearmController == null)
            {
                return Vector3.zero;
            }
            return firearmController.Fireport.position + Camera.main.transform.forward * 1f;
        }

        public static Vector3 SkeletonBonePos(Diz.Skinning.Skeleton sko, int id)
        {
            return sko.Bones.ElementAt(id).Value.position;
        }

        public Vector3 GetBonePosByID(Player p, int id)
        {
            Vector3 result;
            try
            {
                result = SkeletonBonePos(p.PlayerBones.AnimatedTransform.Original.gameObject.GetComponent<PlayerBody>().SkeletonRootJoint, id);
            }
            catch (Exception)
            {
                result = Vector3.zero;
            }
            return result;
        }

        public enum ibid
        {
            Head,
            Neck,
            Chest,
            Stomach
        }

        public int idtobid(ibid bid)
        {
            switch (bid)
            {
                case ibid.Neck:
                    return 132;

                case ibid.Chest:
                    return 36;

                case ibid.Stomach:
                    return 29;

                default:
                    return 133;
            }
        }

        public Vector3 getBonePos(Player inP)
        {
            int bid = idtobid(ibid.Neck);
            return this.GetBonePosByID(inP, bid);
        }

        public static float CalcInFov(Vector3 Position)
        {
            Vector3 position = Camera.main.transform.position;
            Vector3 forward = Camera.main.transform.forward;
            Vector3 normalized = (Position - position).normalized;
            return Mathf.Acos(Mathf.Clamp(Vector3.Dot(forward, normalized), -1f, 1f)) * 57.29578f;
        }

        public void AimAtPos(Vector3 pos)
        {
            Vector2 rotation = LocalPlayer.MovementContext.Rotation;
            Vector3 b = GetShootPos();
            Vector3 eulerAngles = Quaternion.LookRotation((pos - b).normalized).eulerAngles;
            if (eulerAngles.x > 180f)
            {
                eulerAngles.x -= 360f;
            }
            LocalPlayer.MovementContext.Rotation = new Vector2(eulerAngles.y, eulerAngles.x);
        }
    }
}