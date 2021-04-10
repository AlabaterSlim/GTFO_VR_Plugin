﻿using GTFO_VR.Core.PlayerBehaviours;
using HarmonyLib;
using Player;


namespace GTFO_VR_BepInEx.Core
{
    /// <summary>
    /// Get local player reference
    /// </summary>

    [HarmonyPatch(typeof(PlayerAgent),"Setup")]
    class InjectGetLocalPlayerAgentRef
    {
        static void Postfix(PlayerAgent __instance)
        {
            if(__instance.IsLocallyOwned)
            {
                PlayerVR.playerAgent = __instance;
            }
        }
    }
}