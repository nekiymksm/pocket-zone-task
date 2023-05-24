using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _PocketZone.Scripts.ModuleMap.Configs
{
    [CreateAssetMenu(fileName = "MapsCollection", menuName = "Configs/Modules/Map/MapsCollection")]
    public class MapsCollection : ScriptableObject
    {
        [SerializeField] private MapConfig[] _mapConfigs;

        public MapConfig GetMapConfig()
        {
            return _mapConfigs[Random.Range(0, _mapConfigs.Length)];
        }
    }

    [Serializable]
    public class MapConfig
    {
        [SerializeField] private Map _prefab;
        [SerializeField] private float _horizontalLimit;
        [SerializeField] private float _verticalLimit;

        public Map Prefab => _prefab;
        public float HorizontalLimit => _horizontalLimit;
        public float VerticalLimit => _verticalLimit;
    }
}