using System;
using UnityEngine;

namespace _PocketZone.Scripts.ModuleWeapon.Configs
{
    public enum WeaponKind
    {
        AK,
        PM
    }
    
    [CreateAssetMenu(fileName = "WeaponsCollection", menuName = "Configs/Modules/Weapons/WeaponsCollection")]
    public class WeaponsCollection : ScriptableObject
    {
        [SerializeField] private WeaponConfig[] _weaponConfigs;

        public WeaponConfig GetItem(WeaponKind kind)
        {
            return _weaponConfigs[(int)kind];
        }
    }

    [Serializable]
    public class WeaponConfig
    {
        [SerializeField] private WeaponKind _weaponKind;
        [SerializeField] private Weapon _weaponPrefab;
        [SerializeField] private Projectile _projectilePrefab;
        [SerializeField] private float _projectileDistance;
        [SerializeField] private float _projectileSpeed;

        public WeaponKind WeaponKind => _weaponKind;
        public Weapon WeaponPrefab => _weaponPrefab;
        public Projectile ProjectilePrefab => _projectilePrefab;
        public float ProjectileDistance => _projectileDistance;
        public float ProjectileSpeed => _projectileSpeed;
    }
}