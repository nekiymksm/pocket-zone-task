using UnityEngine;

namespace _PocketZone.Scripts.ModulePlayer.Configs
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/Modules/Player/PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        [SerializeField] private Player _playerPrefab;
        [SerializeField] private float _movementSpeed;
        [SerializeField] private int _healthValue;

        public Player PlayerPrefab => _playerPrefab;
        public float MovementSpeed => _movementSpeed;
        public int HealthValue => _healthValue;
    }
}