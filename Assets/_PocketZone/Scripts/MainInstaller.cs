using _PocketZone.Scripts.ModuleCamera;
using _PocketZone.Scripts.ModuleCamera.Configs;
using _PocketZone.Scripts.ModuleEnemies;
using _PocketZone.Scripts.ModuleEnemies.Configs;
using _PocketZone.Scripts.ModuleItems;
using _PocketZone.Scripts.ModuleItems.Configs;
using _PocketZone.Scripts.ModuleMap;
using _PocketZone.Scripts.ModuleMap.Configs;
using _PocketZone.Scripts.ModulePlayer;
using _PocketZone.Scripts.ModulePlayer.Configs;
using _PocketZone.Scripts.ModuleStages;
using _PocketZone.Scripts.ModuleStages.Configs;
using _PocketZone.Scripts.ModuleUi;
using _PocketZone.Scripts.ModuleUi.Configs;
using _PocketZone.Scripts.ModuleUtilities;
using _PocketZone.Scripts.ModuleWeapon;
using _PocketZone.Scripts.ModuleWeapon.Configs;
using UnityEngine;
using Zenject;

namespace _PocketZone.Scripts
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private MainConfig _mainConfig;
        
        public override void InstallBindings()
        {
            UtilitiesModuleInstaller.Install(Container);
            StagesModuleInstaller.Install(Container, _mainConfig.GetConfig<StagesModuleConfig>());
            MapModuleInstaller.Install(Container, _mainConfig.GetConfig<MapModuleConfig>());
            ItemsModuleInstaller.Install(Container, _mainConfig.GetConfig<ItemsModuleConfig>());
            UiModuleInstaller.Install(Container, _mainConfig.GetConfig<UiModuleConfig>());
            PlayerModuleInstaller.Install(Container, _mainConfig.GetConfig<PlayerModuleConfig>());
            WeaponModuleInstaller.Install(Container, _mainConfig.GetConfig<WeaponsModuleConfig>());
            CameraModuleInstaller.Install(Container, _mainConfig.GetConfig<CameraModuleConfig>());
            EnemiesModuleInstaller.Install(Container, _mainConfig.GetConfig<EnemiesModuleConfig>());
        }
    }
}