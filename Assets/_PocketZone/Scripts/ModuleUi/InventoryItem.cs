using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _PocketZone.Scripts.ModuleUi
{
    public class InventoryItem : MonoBehaviour
    {
        [SerializeField] private Button _view;
        [SerializeField] private TextMeshProUGUI _countText;

        private InventoryItemControl _itemControl;

        public int Id { get; private set; }

        private void Awake()
        {
            _view.onClick.AddListener(OnItemButtonClick); ;
        }

        private void OnDestroy()
        {
            _view.onClick.RemoveListener(OnItemButtonClick);
        }

        public void Set(int id, Sprite sprite, int itemsCount, InventoryItemControl itemControl)
        {
            Id = id;
            _itemControl = itemControl;
            
            _view.image.sprite = sprite;
            _countText.SetText(itemsCount > 1 ? itemsCount.ToString() : null);
        }

        private void OnItemButtonClick()
        {
            _itemControl.Show(this);
        }
    }
}