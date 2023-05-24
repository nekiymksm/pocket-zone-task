using _PocketZone.Scripts.ModuleStages.Configs;
using Zenject;

namespace _PocketZone.Scripts.ModuleStages
{
    public class StagesModuleInstaller : Installer<StagesModuleConfig, StagesModuleInstaller>
    {
        private StagesModuleConfig _stagesModuleConfig;

        public StagesModuleInstaller(StagesModuleConfig stagesModuleConfig)
        {
            _stagesModuleConfig = stagesModuleConfig;
        }
        
        public override void InstallBindings()
        {
            Container.Bind<StagesCollection>().FromScriptableObject(_stagesModuleConfig.StagesCollection).AsSingle();
        }
    }
}