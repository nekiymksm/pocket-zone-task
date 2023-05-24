using _PocketZone.Scripts.ModuleEnemies.Configs;
using _PocketZone.Scripts.ModuleItems;
using _PocketZone.Scripts.ModuleItems.Configs;
using _PocketZone.Scripts.ModuleMap;
using _PocketZone.Scripts.ModulePlayer;
using _PocketZone.Scripts.ModuleWeapon;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _PocketZone.Scripts.ModuleEnemies
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyBehavior _behavior;
        [SerializeField] private Image _healthBar;

        private EnemyConfig _enemyConfig;
        private Map _map;
        private ItemsCollection _itemsCollection;
        private ItemsLoad _itemsLoad;
        private float _healthValue;
        private float _attackRateCounter;
        private bool _canAttack;
        private Player _player;

        public int Id { get; private set; }

        [Inject]
        private void Construct(ItemsCollection itemsCollection, 
            ItemsLoad itemsLoad, Map map)
        {
            _itemsCollection = itemsCollection;
            _itemsLoad = itemsLoad;
            _map = map;
        }
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.TryGetComponent(out Projectile projectile))
            {
                TakeDamage();
                Destroy(projectile.gameObject);
            }
            else if (collision.collider.TryGetComponent(out Player player))
            {
                _canAttack = true;
                _player = player;
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.collider.TryGetComponent(out Player player))
            {
                _canAttack = false;
                _player = null;
            }
        }

        private void Update()
        {
            if (_canAttack && _attackRateCounter >= _enemyConfig.RateOfAttack)
            {
                _attackRateCounter = 0;
                _player.TakeDamage();
            }
            
            if (_attackRateCounter < _enemyConfig.RateOfAttack)
            {
                _attackRateCounter += Time.deltaTime;
            }
        }

        public void Init(int id, EnemyConfig enemyConfig)
        {
            Id = id;
            _enemyConfig = enemyConfig;
            _healthValue = enemyConfig.HealthValue;
            
            _canAttack = false;
            _attackRateCounter = 0;

            _behavior.Init(enemyConfig, _map);
        }

        private void TakeDamage()
        {
            _healthBar.fillAmount -= 1 / _healthValue; 
            
            if (_healthBar.fillAmount <= 0)
            {
                _itemsLoad.CreateItem(_itemsCollection.GetRandomConfig(), transform.position);
                Destroy(gameObject);
            }
        }
    }
}