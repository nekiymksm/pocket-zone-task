using UnityEngine;

namespace _PocketZone.Scripts.ModuleCamera.Configs
{
    [CreateAssetMenu(fileName = "CameraModuleConfig", menuName = "Configs/Modules/Camera/CameraModuleConfig")]
    public class CameraModuleConfig : ModuleConfig
    {
        [SerializeField] private Camera _cameraPrefab;

        public Camera CameraPrefab => _cameraPrefab;
    }
}