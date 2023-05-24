using _PocketZone.Scripts.ModuleWeapon.Configs;
using Zenject;

namespace _PocketZone.Scripts.ModuleWeapon
{
    public class WeaponModuleInstaller : Installer<WeaponsModuleConfig, WeaponModuleInstaller>
    {
        private WeaponsModuleConfig _weaponsModuleConfig;
        
        public WeaponModuleInstaller(WeaponsModuleConfig weaponsModuleConfig)
        {
            _weaponsModuleConfig = weaponsModuleConfig;
        }
        
        public override void InstallBindings()
        {
            Container.Bind<WeaponsCollection>().FromScriptableObject(_weaponsModuleConfig.WeaponsCollection).AsSingle();
        }
    }
}