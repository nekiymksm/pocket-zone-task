using System;
using UnityEngine;

namespace _PocketZone.Scripts.ModuleEnemies.Configs
{
    public enum EnemyKind
    {
        Flesh,
        Zombie
    }
    
    [CreateAssetMenu(fileName = "EnemiesCollection", menuName = "Configs/Modules/Enemies/EnemiesCollection")]
    public class EnemiesCollection : ScriptableObject
    {
        [SerializeField] private EnemyConfig[] _enemyConfigs;

        public EnemyConfig GetEnemyConfig(EnemyKind kind)
        {
            for (int i = 0; i < _enemyConfigs.Length; i++)
            {
                if (_enemyConfigs[i].Kind == kind)
                {
                    return _enemyConfigs[i];
                }
            }

            return _enemyConfigs[0];
        }
    }

    [Serializable]
    public class EnemyConfig
    {
        [SerializeField] private EnemyKind _kind;
        [SerializeField] private Enemy _prefab;
        [SerializeField] private int _healthValue;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rateOfAttack;

        public EnemyKind Kind => _kind;
        public Enemy Prefab => _prefab;
        public int HealthValue => _healthValue;
        public float MoveSpeed => _moveSpeed;
        public float RateOfAttack => _rateOfAttack;
    }
}