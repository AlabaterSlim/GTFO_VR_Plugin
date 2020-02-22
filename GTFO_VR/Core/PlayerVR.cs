﻿using GTFO_VR.Events;
using GTFO_VR.Input;
using Player;
using System;
using UnityEngine;
using Valve.VR;
using Valve.VR.Extras;

namespace GTFO_VR
{
    public class PlayerVR : MonoBehaviour
    {

        public static bool VRSetup;

        public static GameObject origin;

        public static PlayerCharacterController playerController;

        public static FPSCamera fpscamera;

        public static PlayerGuiLayer PlayerGui;

        public static bool LoadedAndInGame = false;

        public static SteamVR_Camera VRCamera;

        static Quaternion snapTurnRot = Quaternion.identity;

        static bool UIVisible = true;

        LaserPointer pointer;

        void Awake()
        {
            if (VRSetup)
            {
                Debug.LogWarning("Trying to create duplicate VRInit class...");
                return;
            }

        }

        void Update()
        {
            if(!fpscamera)
            {
                VRSetup = false;
            }
            // Ugly, but works for now
            if(!VRSetup && FocusStateManager.CurrentState.Equals(eFocusState.InElevator))
            {
                if (!fpscamera)
                {
                    Debug.LogWarning("Performing performance heavy lookup for fpscamera...");
                    fpscamera = FindObjectOfType<FPSCamera>();
                }

                if (!playerController)
                {
                    Debug.LogWarning("Performing performance heavy lookup for playerController...");
                    playerController = FindObjectOfType<PlayerCharacterController>();
                }

                if (fpscamera && playerController && !VRSetup )
                {
                    Setup();
                }
            } else
            {
                UpdateOrigin();
            }
        }

        void LateUpdate()
        {
            if (!VRSetup)
            {
                return;
            }

            DoUglyCameraHack();
           
            if(PlayerGui != null && VRInput.GetActionDown(InputAction.Aim))
            {
                UIVisible = !UIVisible;
                PlayerGui.SetVisible(UIVisible);
                PlayerGui.Inventory.SetVisible(false);
                PlayerGui.m_playerStatus.SetVisible(UIVisible);
                PlayerGui.m_compass.SetVisible(UIVisible);
            }
            //UpdateOrigin();
        }

        public static void SetPlayerGUIInstance(PlayerGuiLayer gui)
        {
            PlayerGui = gui;
        }

        private void UpdateOrigin()
        {
            if(origin == null || playerController == null)
            {
                return;
            }
            origin.transform.position = playerController.SmoothPosition;          
        }

        private void Setup()
        {
            Debug.Log("Enabling VR player");
            SetupOrigin();
            SetupLaserPointer();
            SetupVRPlayerCamera();
            VRSetup = true;
            LoadedAndInGame = true;
        }

        private void SetupOrigin()
        {
            if(origin)
            {
                return;
            }
            origin = new GameObject("Origin");
            Controllers.SetOrigin(origin.transform);
            DontDestroyOnLoad(origin);
        }

        private void SetupLaserPointer()
        {
            if(pointer)
            {
                return;
            }
            GameObject laserPointer = new GameObject("LaserPointer");
            pointer = laserPointer.AddComponent<LaserPointer>();
            pointer.color = Color.red;
        }

        private void SetupVRPlayerCamera()
        {
            if (VRCamera)
            {
                return;
            }
            // Handle head transform manually to better fit into the game's systems and allow things like syncing lookDir online
            // This is handled in harmony injections to FPSCamera
            VRCamera = fpscamera.gameObject.AddComponent<SteamVR_Camera>();
            CellSettingsApply.ApplyWorldFOV((int)SteamVR.instance.fieldOfView);
        }

        private void DoUglyCameraHack()
        {
            if (fpscamera != null && fpscamera.m_camera != null)
            {
                fpscamera.m_camera.fieldOfView = SteamVR.instance.fieldOfView;
                fpscamera.m_camera.aspect = SteamVR.instance.aspect;
                if (fpscamera.m_itemCamera != null)
                {
                    fpscamera.m_itemCamera.fieldOfView = SteamVR.instance.fieldOfView;
                    fpscamera.m_itemCamera.aspect = SteamVR.instance.aspect;
                }
            }

            if (ClusteredRendering.Current != null && ClusteredRendering.Current.m_lightBufferCamera != null)
            {
                ClusteredRendering.Current.m_lightBufferCamera.fieldOfView = SteamVR.instance.fieldOfView;
                ClusteredRendering.Current.m_lightBufferCamera.aspect = SteamVR.instance.aspect;
            }

            foreach(SteamVR_Camera cam in SteamVR_Render.instance.cameras)
            {
                cam.camera.enabled = false;
            }
        }

        void OnDestroy()
        {
            Destroy(pointer.gameObject);
        }

    }
}
