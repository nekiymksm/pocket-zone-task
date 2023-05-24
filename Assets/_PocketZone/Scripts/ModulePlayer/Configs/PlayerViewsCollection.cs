using UnityEngine;

namespace _PocketZone.Scripts.ModulePlayer.Configs
{
    [CreateAssetMenu(fileName = "PlayerViewsCollection", menuName = "Configs/Modules/Player/PlayerViewsCollection")]
    public class PlayerViewsCollection : ScriptableObject
    {
        [SerializeField] private Sprite[] _heads;
        [SerializeField] private Sprite[] _hands;
        [SerializeField] private Sprite[] _torsos;
        [SerializeField] private Sprite[] _legs;
        
        public Sprite[] Heads => _heads;
        public Sprite[] Hands => _hands;
        public Sprite[] Torsos => _torsos;
        public Sprite[] Legs => _legs;
    }
}