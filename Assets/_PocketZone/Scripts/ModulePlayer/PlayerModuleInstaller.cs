using _PocketZone.Scripts.ModulePlayer.Configs;
using Zenject;

namespace _PocketZone.Scripts.ModulePlayer
{
    public class PlayerModuleInstaller : Installer<PlayerModuleConfig, PlayerModuleInstaller>
    {
        private PlayerModuleConfig _playerModuleConfig;
        
        public PlayerModuleInstaller(PlayerModuleConfig playerModuleConfig)
        {
            _playerModuleConfig = playerModuleConfig;
        }
        
        public override void InstallBindings()
        {
            Container.Bind<PlayerViewsCollection>()
                .FromScriptableObject(_playerModuleConfig.PlayerViewsCollection).AsSingle();
            Container.Bind<PlayerConfig>()
                .FromScriptableObject(_playerModuleConfig.PlayerConfig).AsSingle();
            Container.Bind<StartItemPacksCollection>()
                .FromScriptableObject(_playerModuleConfig.StartItemPacksCollection).AsSingle();
            
            Container.Bind<PlayerCreation>().AsSingle().NonLazy();
        }
    }
}