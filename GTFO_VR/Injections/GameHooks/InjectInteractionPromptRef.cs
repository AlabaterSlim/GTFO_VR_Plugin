﻿using GTFO_VR.UI;
using HarmonyLib;


namespace GTFO_VR.Injections
{

    [HarmonyPatch(typeof(InteractionGuiLayer), nameof(InteractionGuiLayer.Setup))]
    class InjectInteractionPromptRef
    {
        static void Postfix(InteractionGuiLayer __instance)
        {
            VRWorldSpaceUI.SetInteractionPromptRef(__instance.m_message, __instance.m_interactPrompt, __instance);
        }
    }

}