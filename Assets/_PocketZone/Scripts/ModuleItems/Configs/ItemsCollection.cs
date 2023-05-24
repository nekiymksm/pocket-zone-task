using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _PocketZone.Scripts.ModuleItems.Configs
{
    public enum ItemKind
    {
        Weapon = 0,
        Clothes = 1,
        Ammo = 2
    }
    
    [CreateAssetMenu(fileName = "ItemsCollection", menuName = "Configs/Modules/Items/ItemsCollection")]
    public class ItemsCollection : ScriptableObject
    {
        [SerializeField] private PickableItem _blankItemPrefab;
        [SerializeField] private ItemConfig[] _itemConfigs;

        public PickableItem BlankItemPrefab => _blankItemPrefab;
        
        public ItemConfig GetConfig(int id)
        {
            for (int i = 0; i < _itemConfigs.Length; i++)
            {
                if (_itemConfigs[i].Id == id)
                {
                    return _itemConfigs[i];
                }
            }

            return null;
        }
        
        public ItemConfig GetRandomConfig()
        {
            return _itemConfigs[Random.Range(0, _itemConfigs.Length)];
        }
    }

    [Serializable]
    public class ItemConfig
    {
        [SerializeField] private ItemKind _kind;
        [SerializeField] private Sprite _view;
        [SerializeField] private int _id;
        
        public ItemKind Kind => _kind;
        public Sprite View => _view;
        public int Id => _id;
    }
}