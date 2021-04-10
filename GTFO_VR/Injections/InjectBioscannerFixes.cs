﻿using Gear;
using GTFO_VR.Core.VR_Input;
using HarmonyLib;
using UnityEngine;

namespace GTFO_VR_BepInEx.Core
{

    /// <summary>
    /// Makes Bioscanner work off of gun pos/rot instead of player pos/rot
    /// </summary>
    [HarmonyPatch(typeof(EnemyScannerGraphics), "UpdateCameraOrientation")]
    class InjectRenderBioScannerOffAimDir
    {
        static void Prefix(ref Vector3 position, ref Vector3 forward)
        {
            position = Controllers.GetAimFromPos();
            forward = Controllers.GetAimForward();
        }
    }

}