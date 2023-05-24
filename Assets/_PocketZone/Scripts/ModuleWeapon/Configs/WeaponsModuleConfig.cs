using UnityEngine;

namespace _PocketZone.Scripts.ModuleWeapon.Configs
{
    [CreateAssetMenu(fileName = "WeaponsModuleConfig", menuName = "Configs/Modules/Weapons/WeaponsModuleConfig")]
    public class WeaponsModuleConfig : ModuleConfig
    {
        [SerializeField] private WeaponsCollection _weaponsCollection;
        
        public WeaponsCollection WeaponsCollection => _weaponsCollection;
    }
}