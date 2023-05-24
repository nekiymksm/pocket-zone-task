using _PocketZone.Scripts.ModuleItems.Configs;
using _PocketZone.Scripts.ModulePlayer;
using _PocketZone.Scripts.ModuleWeapon.Configs;
using UnityEngine;

namespace _PocketZone.Scripts.ModuleWeapon
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private WeaponsCollection _weaponsCollection;
        [SerializeField] private Transform _projectileStartPointTransform;
        [SerializeField] private WeaponKind _kind;

        private PlayerAim _playerAim;
        private Inventory _inventory;
        private WeaponConfig _weaponConfig;

        private void Start()
        {
            _weaponConfig = _weaponsCollection.GetItem(_kind);
        }

        public void Init(PlayerAim playerAim, Inventory inventory)
        {
            _playerAim = playerAim;
            _inventory = inventory;
        }
        
        public void Shot()
        {
            if (_playerAim.HasTarget == false)
            {
                return;
            }
            
            if (_inventory.Items.TryGetValue((int)ItemKind.Ammo, out int count))
            {
                if (count <= 0)
                {
                    return;
                }
            }
            else
            {
                return;
            }
            
            _inventory.BreakItem((int) ItemKind.Ammo);

            var startPosition = _projectileStartPointTransform.position;
            var direction = _playerAim.EnemyPosition - startPosition;
            
            var projectile = Instantiate(_weaponConfig.ProjectilePrefab, startPosition, Quaternion.identity);
            projectile.Init(startPosition, direction, _weaponConfig);
        }
    }
}