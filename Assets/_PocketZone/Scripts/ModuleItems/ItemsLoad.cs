using _PocketZone.Scripts.ModuleItems.Configs;
using _PocketZone.Scripts.ModuleMap;
using _PocketZone.Scripts.ModuleStages.Configs;
using UnityEngine;

namespace _PocketZone.Scripts.ModuleItems
{
    public class ItemsLoad
    {
        private Map _map;
        private StagesCollection _stagesCollection;
        private ItemsCollection _itemsCollection;
        
        public ItemsLoad(Map map, StagesCollection stagesCollection, ItemsCollection itemsCollection)
        {
            _map = map;
            _stagesCollection = stagesCollection;
            _itemsCollection = itemsCollection;
            
            Load();
        }

        public void CreateItem(ItemConfig itemConfig, Vector3 spawnPosition)
        {
            var item = Object.Instantiate(_itemsCollection.BlankItemPrefab, spawnPosition, Quaternion.identity);
            item.Init(itemConfig.View, itemConfig.Id);
        }
        
        private void Load()
        {
            var stageConfig = _stagesCollection.GetConfig(Stage.Test);
            
            for (int i = 0; i < stageConfig.PickableItemsCount; i++)
            {
                CreateItem(_itemsCollection.GetRandomConfig(), GetSpawnPoint());
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