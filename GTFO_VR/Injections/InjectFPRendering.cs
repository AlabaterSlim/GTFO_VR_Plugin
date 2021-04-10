﻿using HarmonyLib;
using Player;
using UnityEngine;


namespace GTFO_VR_BepInEx.Core
{
    /// <summary>
    /// Makes most items render normally instead of 'flattened' to the screen
    /// </summary>
    [HarmonyPatch(typeof(PlayerBackpackManager), "SetFPSRendering")]
    class InjectRenderFirstPersonItemsForVR
    {
        static void Prefix(ref bool enable, GameObject go)
        {
            enable = false;
            foreach (var m in go.GetComponentsInChildren<MeshRenderer>(true))
            {
                if (m == null || m.sharedMaterials == null)
                {
                    continue;
                }
                foreach(Material mat in m.sharedMaterials)
                {
                    if(mat != null)
                    {
                        mat.DisableKeyword("ENABLE_FPS_RENDERING");
                        mat.DisableKeyword("FPS_RENDERING_ALLOWED");
                    }

                }
                
            }
            
        }
    }
    
    /// <summary>
    /// Makes the hacking tool render normally instead of in 2D
    /// </summary>
    [HarmonyPatch(typeof(HologramGraphics), nameof(HologramGraphics.AddHoloPart))]
    class InjectRenderFirstPersonHackingToolForVR
    {
        static void Prefix(HologramGraphicsPart part, HologramGraphics __instance)
        {
            Material material = part.m_renderer.sharedMaterial;
            material.DisableKeyword("ENABLE_FPS_RENDERING");
            material.DisableKeyword("FPS_RENDERING_ALLOWED");
        }
    }
    

    /// <summary>
    /// Disables FPS arms rendering, it's really wonky in VR so it's better to not see it at all
    /// </summary>

    [HarmonyPatch(typeof(FirstPersonItemHolder), "SetupFPSRig")]
    class InjectDisableFPSArms
    {
        static void Postfix(FirstPersonItemHolder __instance)
        {
            foreach (Renderer renderer in __instance.FPSArms.GetComponentsInChildren<Renderer>())
            {
                renderer.enabled = false;
            }
        }
    }

}