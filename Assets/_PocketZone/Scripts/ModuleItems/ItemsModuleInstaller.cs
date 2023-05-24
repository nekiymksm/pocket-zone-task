using _PocketZone.Scripts.ModuleItems.Configs;
using Zenject;

namespace _PocketZone.Scripts.ModuleItems
{
    public class ItemsModuleInstaller : Installer<ItemsModuleConfig, ItemsModuleInstaller>
    {
        private ItemsModuleConfig _itemsModuleConfig;
        
        public ItemsModuleInstaller(ItemsModuleConfig itemsModuleConfig)
        {
            _itemsModuleConfig = itemsModuleConfig;
        }
        
        public override void InstallBindings()
        {
            Container.Bind<ItemsCollection>().FromScriptableObject(_itemsModuleConfig.ItemsCollection).AsSingle();

            Container.Bind<ItemsLoad>().AsSingle().NonLazy();
        }
    }
}