using _PocketZone.Scripts.ModuleMap.Configs;
using Zenject;

namespace _PocketZone.Scripts.ModuleMap
{
    public class MapLoad
    {
        public MapLoad(DiContainer diContainer, MapsCollection mapsCollection)
        {
            var config = mapsCollection.GetMapConfig();
            var map = diContainer.InstantiatePrefabForComponent<Map>(config.Prefab);
            
            map.Init(config);
            diContainer.Bind<Map>().FromInstance(map).AsSingle();
        }
    }
}