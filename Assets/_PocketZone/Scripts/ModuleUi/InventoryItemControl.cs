using _PocketZone.Scripts.ModuleUi.UiElements;
using UnityEngine;
using UnityEngine.UI;

namespace _PocketZone.Scripts.ModuleUi
{
    public class InventoryItemControl : MonoBehaviour
    {
        [SerializeField] private InventoryUi _inventory;
        [SerializeField] private Button _breakItemButton;
        
        private InventoryItem _currentItem;

        private void Awake()
        {
            _breakItemButton.onClick.AddListener(OnBreakButtonClick);
        }

        private void OnDestroy()
        {
            _breakItemButton.onClick.RemoveListener(OnBreakButtonClick);
        }

        public void Show(InventoryItem currentItem)
        {
            gameObject.SetActive(true);
            _currentItem = currentItem;
        }
        
        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void OnBreakButtonClick()
        {
            if (_currentItem == null)
            {
                return;
            }
            
            _inventory.OnItemBreak(_currentItem);
            _currentItem = null;
        }
    }
}