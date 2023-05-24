using UnityEngine;

namespace _PocketZone.Scripts.ModulePlayer.Configs
{
    [CreateAssetMenu(fileName = "PlayerModuleConfig", menuName = "Configs/Modules/Player/PlayerModuleConfig")]
    public class PlayerModuleConfig : ModuleConfig
    {
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private PlayerViewsCollection _playerViewsCollection;
        [SerializeField] private StartItemPacksCollection _startItemPacksCollection;
        
        public PlayerConfig PlayerConfig => _playerConfig;
        public PlayerViewsCollection PlayerViewsCollection => _playerViewsCollection;
        public StartItemPacksCollection StartItemPacksCollection => _startItemPacksCollection;
    }
}