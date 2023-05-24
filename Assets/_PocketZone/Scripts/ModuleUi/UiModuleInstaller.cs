using _PocketZone.Scripts.ModuleUi.Configs;
using Zenject;

namespace _PocketZone.Scripts.ModuleUi
{
    public class UiModuleInstaller : Installer<UiModuleConfig, UiModuleInstaller>
    {
        private UiModuleConfig _uiModuleConfig;
        
        public UiModuleInstaller(UiModuleConfig uiModuleConfig)
        {
            _uiModuleConfig = uiModuleConfig;
        }
        
        public override void InstallBindings()
        {
            Container.Bind<UiRoot>().FromComponentInNewPrefab(_uiModuleConfig.UiRootPrefab).AsSingle().NonLazy();
        }
    }
}