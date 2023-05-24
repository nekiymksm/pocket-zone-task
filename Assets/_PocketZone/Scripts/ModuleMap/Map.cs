using _PocketZone.Scripts.ModuleMap.Configs;
using UnityEngine;

namespace _PocketZone.Scripts.ModuleMap
{
    public class Map : MonoBehaviour
    {
        [SerializeField] private Transform _playerSpawnPointTransform;

        public float HorizontalLimit { get; private set; }
        public float VerticalLimit { get; private set; }
        
        public Transform PlayerSpawnPointTransform => _playerSpawnPointTransform;

        public void Init(MapConfig mapConfig)
        {
            HorizontalLimit = mapConfig.HorizontalLimit;
            VerticalLimit = mapConfig.VerticalLimit;
        }
    }
}