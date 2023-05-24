using _PocketZone.Scripts.ModuleCamera.Configs;
using Zenject;

namespace _PocketZone.Scripts.ModuleCamera
{
    public class CameraModuleInstaller : Installer<CameraModuleConfig, CameraModuleInstaller>
    {
        private CameraModuleConfig _cameraModuleConfig;
        
        public CameraModuleInstaller(CameraModuleConfig cameraModuleConfig)
        {
            _cameraModuleConfig = cameraModuleConfig;
        }
        
        public override void InstallBindings()
        {
            Container.Bind<CameraModuleConfig>().FromInstance(_cameraModuleConfig).AsSingle();
            
            Container.Bind<CameraLoad>().AsSingle().NonLazy();
        }
    }
}