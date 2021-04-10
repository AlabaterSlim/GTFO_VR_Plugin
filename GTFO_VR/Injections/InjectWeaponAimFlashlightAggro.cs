﻿using GTFO_VR.Core.PlayerBehaviours;
using GTFO_VR.Core.VR_Input;
using HarmonyLib;
using Player;
using UnityEngine;


namespace GTFO_VR_BepInEx.Core
{
    /// <summary>
    /// Change detection to use weapon flashlight direction (when you're the host or playing solo)
    /// </summary>
    [HarmonyPatch(typeof(PlayerAgent), "GetDetectionMod")]
    class InjectWeaponAimFlashlightAggro
    {
        static void Postfix(PlayerAgent __instance, Vector3 dir, float distance, ref float __result)
        {
            __result = PlayerVR.VRDetectionMod(dir, distance, __instance.Inventory.m_flashlight.range, __instance.Inventory.m_flashlight.spotAngle);
        }
    }
}