using System;
using _PocketZone.Scripts.ModuleEnemies.Configs;
using _PocketZone.Scripts.ModuleMap;
using _PocketZone.Scripts.ModuleStages.Configs;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace _PocketZone.Scripts.ModuleEnemies
{
    public class EnemiesLoad
    {
        private DiContainer _container;
        private EnemiesCollection _enemiesCollection;
        private StagesCollection _stagesCollection;
        private Map _map;

        public int EnemiesCounter { get; private set; }
        
        public EnemiesLoad(DiContainer container, EnemiesCollection enemiesCollection, StagesCollection stagesCollection, 
            Map map)
        {
            _container = container;
            _enemiesCollection = enemiesCollection;
            _stagesCollection = stagesCollection;
            _map = map;

            Load();
        }

        private void Load()
        {
            EnemiesCounter = 0;
            
            var stage = _stagesCollection.GetConfig(Stage.Test);
            var enemyKinds = Enum.GetValues(typeof(EnemyKind));

            for (int i = 0; i < stage.EnemiesCount; i++)
            {
                var enemyConfig = _enemiesCollection.GetEnemyConfig((EnemyKind)Random.Range(0, enemyKinds.Length));
                var enemy = _container.InstantiatePrefabForComponent<Enemy>(enemyConfig.Prefab, 
                    GetSpawnPoint(), Quaternion.identity, null);
                enemy.Init(EnemiesCounter, enemyConfig);
                
                EnemiesCounter++;
            }
        }

        private Vector2 GetSpawnPoint()
        {
            var horizontal = Random.Range(-_map.HorizontalLimit, _map.HorizontalLimit);
            var vertical = Random.Range(-_map.VerticalLimit, _map.VerticalLimit);

            return new Vector2(horizontal, vertical);
        }
    }
}