using UnityEngine;

namespace _PocketZone.Scripts.ModuleEnemies.Configs
{
    [CreateAssetMenu(fileName = "EnemiesModuleConfig", menuName = "Configs/Modules/Enemies/EnemiesModuleConfig")]
    public class EnemiesModuleConfig : ModuleConfig
    {
        [SerializeField] private EnemiesCollection _enemiesCollection;
        
        public EnemiesCollection EnemiesCollection => _enemiesCollection;
    }
}