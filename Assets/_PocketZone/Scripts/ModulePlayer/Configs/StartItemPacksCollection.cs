using System;
using UnityEngine;

namespace _PocketZone.Scripts.ModulePlayer.Configs
{
    [CreateAssetMenu(fileName = "StartItemPacksCollection", menuName = "Configs/Modules/Player/StartItemPacksCollection")]
    public class StartItemPacksCollection : ScriptableObject
    {
        [SerializeField] private ItemsPackConfig[] packConfigs;
        
        public ItemsPackConfig[] PackConfigs => packConfigs;
    }

    [Serializable]
    public class ItemsPackConfig
    {
        [SerializeField] private int _itemId;
        [SerializeField] private int _itemsValue;
        
        public int ItemId => _itemId;
        public int ItemsValue => _itemsValue;
    }
}