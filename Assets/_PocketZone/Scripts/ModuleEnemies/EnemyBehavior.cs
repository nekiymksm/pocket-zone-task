using _PocketZone.Scripts.ModuleEnemies.Configs;
using _PocketZone.Scripts.ModuleMap;
using _PocketZone.Scripts.ModulePlayer;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _PocketZone.Scripts.ModuleEnemies
{
    public class EnemyBehavior : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        
        private EnemyConfig _enemyConfig;
        private Map _map;
        private Vector3 _currentTargetPosition;
        private bool _isPlayer;
        
        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.TryGetComponent(out Player player))
            {
                _isPlayer = true;
            }
        }

        private void OnTriggerStay2D(Collider2D collider)
        {
            if (collider.TryGetComponent(out Player player))
            {
                Move(player.transform.position);
            }
        }
        
        private void OnTriggerExit2D(Collider2D collider)
        {
            if (collider.TryGetComponent(out Player player))
            {
                _isPlayer = false;
            }
        }
        
        private void Update()
        {
            if (_isPlayer == false)
            {
                if (_currentTargetPosition == transform.position)
                {
                    _currentTargetPosition = GetNewTargetPosition();
                }
            
                Move(_currentTargetPosition);
            }
        }

        public void Init(EnemyConfig enemyConfig, Map map)
        {
            _enemyConfig = enemyConfig;
            _map = map;
            _isPlayer = false;
            
            _currentTargetPosition = GetNewTargetPosition();
        }

        private void Move(Vector3 position)
        {
            _rigidbody.transform.position = Vector3.MoveTowards(_rigidbody.transform.position, position,
                _enemyConfig.MoveSpeed * Time.deltaTime);
            
            TryRotate(position);
        }

        private void TryRotate(Vector3 position)
        {
            var yAxisValue = _rigidbody.transform.eulerAngles.y;
            
            if (yAxisValue == 0 && position.x < _rigidbody.transform.position.x)
            {
                _rigidbody.transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else if(yAxisValue >= 180 && position.x > _rigidbody.transform.position.x)
            {
                _rigidbody.transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
        
        private Vector2 GetNewTargetPosition()
        {
            var horizontalValue = Random.Range(-_map.HorizontalLimit, _map.HorizontalLimit);
            var verticalValue = Random.Range(-_map.VerticalLimit, _map.VerticalLimit);
            
            return new Vector2(horizontalValue, verticalValue);
        }
    }
}