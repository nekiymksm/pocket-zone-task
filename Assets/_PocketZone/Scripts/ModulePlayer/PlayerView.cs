using _PocketZone.Scripts.ModulePlayer.Configs;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace _PocketZone.Scripts.ModulePlayer
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _headView;
        [SerializeField] private SpriteRenderer _torsoView;
        
        [SerializeField] private SpriteRenderer _leftHandView;
        [SerializeField] private SpriteRenderer _rightHandView;
        
        [SerializeField] private SpriteRenderer _leftLegView;
        [SerializeField] private SpriteRenderer _rightLegView;

        private PlayerViewsCollection _playerViewsCollection;
        
        [Inject]
        private void Construct(PlayerViewsCollection playerViewsCollection)
        {
            _playerViewsCollection = playerViewsCollection;
        }
        
        private void Start()
        {
            Set();
        }

        private void Set()
        {
            _headView.sprite = _playerViewsCollection.Heads[Random.Range(0, _playerViewsCollection.Heads.Length)];
            _torsoView.sprite = _playerViewsCollection.Torsos[Random.Range(0, _playerViewsCollection.Torsos.Length)];
            
            var hands = _playerViewsCollection.Hands[Random.Range(0, _playerViewsCollection.Hands.Length)];
            _leftHandView.sprite = hands;
            _rightHandView.sprite = hands;
            
            var legs = _playerViewsCollection.Legs[Random.Range(0, _playerViewsCollection.Legs.Length)];
            _leftLegView.sprite = legs;
            _rightLegView.sprite = legs;
        }
    }
}