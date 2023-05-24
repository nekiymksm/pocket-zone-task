using UnityEngine;

namespace _PocketZone.Scripts.ModuleItems.Configs
{
    [CreateAssetMenu(fileName = "ItemsModuleConfig", menuName = "Configs/Modules/Items/ItemsModuleConfig")]
    public class ItemsModuleConfig : ModuleConfig
    {
        [SerializeField] private ItemsCollection _itemsCollection;
        
        public ItemsCollection ItemsCollection => _itemsCollection;
    }
}