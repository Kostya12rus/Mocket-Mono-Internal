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
        // No Recoil

        private void NoRecoil()
        {
            try
            {
                LocalPlayer.ProceduralWeaponAnimation.Shootingg.Intensity = 0;
                LocalPlayer.ProceduralWeaponAnimation.Shootingg.RecoilStrengthXY = new Vector2(0, 0);
                LocalPlayer.ProceduralWeaponAnimation.Shootingg.RecoilStrengthZ = new Vector2(0, 0);
                LocalPlayer.ProceduralWeaponAnimation.WalkEffectorEnabled = false;
                LocalPlayer.ProceduralWeaponAnimation._shouldMoveWeaponCloser = false;
                LocalPlayer.ProceduralWeaponAnimation.MotionReact.SwayFactors.x = 0;
                LocalPlayer.ProceduralWeaponAnimation.MotionReact.SwayFactors.y = 0;
                LocalPlayer.ProceduralWeaponAnimation.MotionReact.SwayFactors.z = 0;
                LocalPlayer.ProceduralWeaponAnimation.Breath.Intensity = 0;
                LocalPlayer.ProceduralWeaponAnimation.Walk.Intensity = 0;
                LocalPlayer.ProceduralWeaponAnimation.Shootingg.Stiffness = 0;
                LocalPlayer.ProceduralWeaponAnimation.MotionReact.Intensity = 0;
                LocalPlayer.ProceduralWeaponAnimation.ForceReact.Intensity = 0;
            }
            catch
            {
            }
        }

        // Day

        private void Day()
        {
            TOD_Sky.Instance.Components.Time.GameDateTime = null;
            TOD_Sky Sky_Obj = (TOD_Sky)FindObjectOfType(typeof(TOD_Sky));
            Sky_Obj.Cycle.Hour = 12f;
            WeatherController.Instance.RainController.enabled = false;
            WeatherController.Instance.GlobalFogOvercast = 0f;
        }

        // Wall Bang

        private void wallBang()
        {
            try
            {
                if (this._wallBang)
                {
                    LocalPlayer.ProceduralWeaponAnimation._shouldMoveWeaponCloser = false;
                }
                else
                {
                    LocalPlayer.ProceduralWeaponAnimation.enabled = true;
                }
            }
            catch
            {
            }
        }

        // Fast Mags / Skills

        private void fastMags()
        {
            try
            {
                LocalPlayer.Skills.MagDrillsInstantCheck.Value = true;
                LocalPlayer.Skills.MagDrillsInventoryCheckAccuracy.Value = 100;
                LocalPlayer.Skills.MagDrillsInventoryCheckSpeed.Value = 100;
                LocalPlayer.Skills.MagDrillsLoadSpeed.Value = 100f;
                LocalPlayer.Skills.MagDrillsUnloadSpeed.Value = 100f;
                LocalPlayer.Skills.AttentionLootSpeed.Value = 20000f;
                LocalPlayer.Skills.StrengthBuffSprintSpeedInc.Value = 20000f;
                LocalPlayer.Skills.VitalityBuffRegeneration.Value = true;
                LocalPlayer.Skills.HealthBreakChanceRed.Value = 0f;
                LocalPlayer.Skills.HealthEliteAbsorbDamage.Value = true;
                LocalPlayer.Skills.EnduranceBuffBreathTimeInc.Value = 20000f;
                LocalPlayer.Skills.EnduranceBuffRestorationTimeRed.Value = 200;
                LocalPlayer.Skills.Strength.Current = 51;
            }
            catch
            {
            }
        }

        // Super Bullets

        private void superBullet()
        {
            try
            {
                if (_superBullet)
                {
                    LocalPlayer.Weapon.Template.DefAmmoTemplate.PenetrationChance = 1000;
                    LocalPlayer.Weapon.Template.DefAmmoTemplate.PenetrationPower = 1000;
                    LocalPlayer.Weapon.Template.DefAmmoTemplate.Damage = 1000;
                    LocalPlayer.Weapon.Template.DefAmmoTemplate.ArmorDamage = 1000;
                    LocalPlayer.Weapon.Template.DefAmmoTemplate.PenetrationPowerDiviation = 0f;
                    LocalPlayer.Weapon.Template.DefAmmoTemplate.RicochetChance = 0;
                    LocalPlayer.Weapon.Template.DefAmmoTemplate.Tracer = true;
                    LocalPlayer.Weapon.Template.DefAmmoTemplate.TracerColor = JsonType.TaxonomyColor.tracerRed;
                    LocalPlayer.Weapon.Template.DefAmmoTemplate.TracerDistance = Mathf.Infinity;
                    LocalPlayer.Weapon.Template.DefAmmoTemplate.Width = 100;
                    LocalPlayer.Weapon.Template.DefAmmoTemplate.Height = 100;
                }
                else
                {
                    LocalPlayer.Weapon.Template.DefAmmoTemplate.Width = 100;
                    LocalPlayer.Weapon.Template.DefAmmoTemplate.Height = 100;
                    LocalPlayer.Weapon.Template.DefAmmoTemplate.PenetrationChance = 1;
                    LocalPlayer.Weapon.Template.DefAmmoTemplate.PenetrationPower = 50;
                    LocalPlayer.Weapon.Template.DefAmmoTemplate.Damage = 50;
                    LocalPlayer.Weapon.Template.DefAmmoTemplate.ArmorDamage = 25;
                    LocalPlayer.Weapon.Template.DefAmmoTemplate.PenetrationPowerDiviation = 0f;
                    LocalPlayer.Weapon.Template.DefAmmoTemplate.RicochetChance = 0;
                    LocalPlayer.Weapon.Template.DefAmmoTemplate.Tracer = false;
                }
            }
            catch
            {
            }
        }
    }
}