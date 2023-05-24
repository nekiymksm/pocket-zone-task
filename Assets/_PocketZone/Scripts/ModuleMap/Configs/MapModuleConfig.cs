using UnityEngine;

namespace _PocketZone.Scripts.ModuleMap.Configs
{
    [CreateAssetMenu(fileName = "MapModuleConfig", menuName = "Configs/Modules/Map/MapModuleConfig")]
    public class MapModuleConfig : ModuleConfig
    {
        [SerializeField] private MapsCollection _mapsCollection;
        
        public MapsCollection MapsCollection => _mapsCollection;
    }
}