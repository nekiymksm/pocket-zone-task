using _PocketZone.Scripts.ModuleMap;
using _PocketZone.Scripts.ModulePlayer.Configs;
using UnityEngine;
using Zenject;

namespace _PocketZone.Scripts.ModulePlayer
{
    public class PlayerCreation
    {
        private StartItemPacksCollection _startItemPacksCollection;
        
        public PlayerCreation(DiContainer diContainer, PlayerConfig playerConfig, Map map,
            StartItemPacksCollection startItemPacksCollection)
        {
            _startItemPacksCollection = startItemPacksCollection;
            
            var player = diContainer.InstantiatePrefabForComponent<Player>(playerConfig.PlayerPrefab,
                map.PlayerSpawnPointTransform.position, Quaternion.identity, null);
            player.Init(this, playerConfig);

            diContainer.Bind<Player>().FromInstance(player).AsSingle();
        }

        public void GiveItems(Inventory inventory)
        {
            var packConfigs = _startItemPacksCollection.PackConfigs;
            
            foreach (var config in packConfigs)
            {
                for (int i = 0; i < config.ItemsValue; i++)
                {
                    inventory.PutItem(config.ItemId);
                }
            }
        }
    }
}