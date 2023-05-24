using _PocketZone.Scripts.ModulePlayer.Configs;
using _PocketZone.Scripts.ModuleUi;
using _PocketZone.Scripts.ModuleUi.UiElements;
using _PocketZone.Scripts.ModuleUtilities;
using Unity.Mathematics;
using UnityEngine;
using Zenject;

namespace _PocketZone.Scripts.ModulePlayer
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private PlayerAim _playerAim;
        [SerializeField] private WeaponBag _weaponBag;
        [SerializeField] private Inventory _inventory;

        private PlayerCreation _playerCreation;
        private PlayerConfig _playerConfig;
        private CharacterMovement _characterMovement;
        private PlayerControlUi _playerControlUi;
        private IndicatorsUi _indicatorsUi;

        private int _healthValue;

        [Inject]
        private void Construct(CharacterMovement characterMovement, UiRoot uiRoot)
        {
            _characterMovement = characterMovement;
            _playerControlUi = uiRoot.GetUiElement<PlayerControlUi>();
            _indicatorsUi = uiRoot.GetUiElement<IndicatorsUi>();

            _weaponBag.WeaponChanged += OnWeaponChange;
            _weaponBag.WeaponEquipped += OnWeaponEquipped;
            _playerControlUi.InventoryButtonClick += _inventory.Show;
        }

        private void Start()
        {
            _playerCreation.GiveItems(_inventory);
            _healthValue = _playerConfig.HealthValue;
        }

        private void FixedUpdate()
        {
            var direction = _playerControlUi.GetMoveDirection();
            
            _characterMovement.Move(_rigidbody, direction, 
                _playerConfig.MovementSpeed, Time.fixedDeltaTime, true);

            if (_playerAim.HasTarget)
            {
                _characterMovement.Rotate(transform, _playerAim.EnemyPosition);
                _weaponBag.EquippedWeapon.transform.LookAt(_playerAim.EnemyPosition);
            }
            else
            {
                _characterMovement.Rotate(transform, direction.x);
                _weaponBag.EquippedWeapon.transform.rotation = 
                    Quaternion.Euler(0, transform.rotation.eulerAngles.y + 90, 0);
            }
        }

        private void OnDestroy()
        {
            _weaponBag.WeaponChanged -= OnWeaponChange;
            _weaponBag.WeaponEquipped -= OnWeaponEquipped;
            _playerControlUi.InventoryButtonClick -= _inventory.Show;
        }

        public void Init(PlayerCreation playerCreation, PlayerConfig playerConfig)
        {
            _playerCreation = playerCreation;
            _playerConfig = playerConfig;
        }
        
        public void TakeDamage()
        {
            _indicatorsUi.SetHealthBar(_playerConfig.HealthValue);
            _healthValue--;
            
            if (_healthValue <= 0)
            {
                Destroy(gameObject);
            }
        }

        private void OnWeaponChange()
        {
            _playerControlUi.ShotButtonClick -= _weaponBag.EquippedWeapon.Shot;
        }
        
        private void OnWeaponEquipped()
        {
            _weaponBag.EquippedWeapon.Init(_playerAim, _inventory);
            _playerControlUi.ShotButtonClick += _weaponBag.EquippedWeapon.Shot;
        }
    }
}