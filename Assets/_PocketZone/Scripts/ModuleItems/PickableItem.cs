using UnityEngine;

namespace _PocketZone.Scripts.ModuleItems
{
    public class PickableItem : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _view;
        
        public int Id { get; private set; }

        public void Init(Sprite view, int id)
        {
            _view.sprite = view;
            Id = id;
        }

        public void Hide()
        {
            Destroy(gameObject);
        }
    }
}