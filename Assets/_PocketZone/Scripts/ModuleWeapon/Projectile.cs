using _PocketZone.Scripts.ModuleWeapon.Configs;
using UnityEngine;

namespace _PocketZone.Scripts.ModuleWeapon
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private Transform _viewTransform;
        
        private Vector3 _startPoint;
        private WeaponConfig _weaponConfig;
        private Vector3 _direction;

        public WeaponKind Kind { get; private set; }

        private void FixedUpdate()
        {
            var passedDistance = Vector3.Distance(_startPoint, transform.position);
                
            transform.Translate(_direction * _weaponConfig.ProjectileSpeed * Time.fixedDeltaTime);
                
            if (passedDistance >= _weaponConfig.ProjectileDistance)
            {
                Destroy(gameObject);
            }
        }

        public void Init(Vector3 startPoint, Vector3 direction, WeaponConfig weaponConfig)
        {
            _startPoint = startPoint;
            _weaponConfig = weaponConfig;
            _direction = direction;
            
            Kind = weaponConfig.WeaponKind;
            
            _viewTransform.rotation = 
                Quaternion.Euler(0, 0, Mathf.Atan(direction.y / direction.x) * Mathf.Rad2Deg + 90);
        }
    }
}