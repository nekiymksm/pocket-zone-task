using _PocketZone.Scripts.ModuleEnemies.Configs;
using Zenject;

namespace _PocketZone.Scripts.ModuleEnemies
{
    public class EnemiesModuleInstaller : Installer<EnemiesModuleConfig, EnemiesModuleInstaller>
    {
        private EnemiesModuleConfig _enemiesModuleConfig;

        public EnemiesModuleInstaller(EnemiesModuleConfig enemiesModuleConfig)
        {
            _enemiesModuleConfig = enemiesModuleConfig;
        }
        
        public override void InstallBindings()
        {
            Container.Bind<EnemiesCollection>().FromScriptableObject(_enemiesModuleConfig.EnemiesCollection).AsSingle();

            Container.Bind<EnemiesLoad>().AsSingle().NonLazy();
        }
    }
}