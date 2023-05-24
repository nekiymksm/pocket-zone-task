using _PocketZone.Scripts.ModuleMap;
using _PocketZone.Scripts.ModulePlayer;
using UnityEngine;
using Zenject;

namespace _PocketZone.Scripts.ModuleCamera
{
    public class PlayerCameraTrack : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        
        private Player _player;

        private float _horizontalLimit;
        private float _verticalLimit;
        
        [Inject]
        public void Construct(Player player, Map map)
        {
            _player = player;

            _horizontalLimit = map.HorizontalLimit - _camera.orthographicSize * _camera.aspect;
            _verticalLimit = map.VerticalLimit - _camera.orthographicSize;
        }

        private void FixedUpdate()
        {
            var position = _player.transform.position;

            position.x = Mathf.Clamp(position.x, -_horizontalLimit, _horizontalLimit);
            position.y = Mathf.Clamp(position.y, -_verticalLimit, _verticalLimit);
            
            transform.position = new Vector3(position.x, position.y, transform.position.z);
        }
    }
}