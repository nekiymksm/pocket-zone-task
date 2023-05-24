using System;
using _PocketZone.Scripts.ModuleWeapon;
using UnityEngine;

namespace _PocketZone.Scripts.ModulePlayer
{
    public class WeaponBag : MonoBehaviour
    {
        [SerializeField] private Weapon _currentWeapon;
        
        public Weapon EquippedWeapon { get; private set; }

        public event Action WeaponEquipped;
        public event Action WeaponChanged;

        private void Start()
        {
            EquipWeapon(_currentWeapon);
        }

        public void EquipWeapon(Weapon weapon)
        {
            EquippedWeapon = weapon;
            WeaponEquipped?.Invoke();
        }
        
        public void ChangeWeapon()
        {
            WeaponChanged?.Invoke();
        }
    }
}