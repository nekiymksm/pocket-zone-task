using _PocketZone.Scripts.ModuleMap.Configs;
using Zenject;

namespace _PocketZone.Scripts.ModuleMap
{
    public class MapModuleInstaller : Installer<MapModuleConfig, MapModuleInstaller>
    {
        private MapModuleConfig _mapModuleConfig;
        
        public MapModuleInstaller(MapModuleConfig mapModuleConfig)
        {
            _mapModuleConfig = mapModuleConfig;
        }
        
        public override void InstallBindings()
        {
            Container.Bind<MapsCollection>().FromScriptableObject(_mapModuleConfig.MapsCollection).AsSingle();

            Container.Bind<MapLoad>().AsSingle().NonLazy();
        }
    }
}