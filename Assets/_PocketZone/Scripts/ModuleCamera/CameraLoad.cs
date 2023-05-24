using _PocketZone.Scripts.ModuleCamera.Configs;
using UnityEngine;
using Zenject;

namespace _PocketZone.Scripts.ModuleCamera
{
    public class CameraLoad
    {
        public CameraLoad(DiContainer container, CameraModuleConfig cameraModuleConfig)
        {
            var camera = container.InstantiatePrefabForComponent<Camera>(cameraModuleConfig.CameraPrefab);
            
            container.Bind<Camera>().FromInstance(camera).AsSingle();
            container.Bind<PlayerCameraTrack>().FromInstance(camera.GetComponent<PlayerCameraTrack>()).AsSingle();
        }
    }
}