using System;
using System.Collections.Generic;
using _PocketZone.Scripts.ModuleItems.Configs;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _PocketZone.Scripts.ModuleUi.UiElements
{
    public class InventoryUi : UiElement
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private Transform _itemsGridContentTransform;
        [SerializeField] private Transform _loadedItemsStashTransform;
        [SerializeField] private InventoryItemControl _itemControl;
        [SerializeField] private InventoryItem _inventoryItemPrefab;
        
        private PlayerControlUi _playerControlUi;
        private IndicatorsUi _indicatorsUi;
        private ItemsCollection _itemsCollection;

        private List<InventoryItem> _loadedItems;
        private int _itemsCounter;

        public event Action<int> BreakItem;

        [Inject]
        private void Construct(UiRoot uiRoot, ItemsCollection itemsCollection)
        {
            _playerControlUi = uiRoot.GetUiElement<PlayerControlUi>();
            _indicatorsUi = uiRoot.GetUiElement<IndicatorsUi>();
            _itemsCollection = itemsCollection;

            _loadedItems = new List<InventoryItem>();
        }

        private void Awake()
        {
            _closeButton.onClick.AddListener(OnCloseButtonClick);
        }

        private void OnDestroy()
        {
            _closeButton.onClick.RemoveListener(OnCloseButtonClick);
        }

        public void Set(Dictionary<int, int> items)
        {
            foreach (var item in _loadedItems)
            {
                item.transform.SetParent(_loadedItemsStashTransform);
                item.gameObject.SetActive(false);
            }
            
            _itemControl.Hide();
            _itemsCounter = _loadedItems.Count;

            foreach (var pickableItem in items)
            {
                var view = _itemsCollection.GetConfig(pickableItem.Key).View;
                GetItem().Set(pickableItem.Key, view, pickableItem.Value, _itemControl);
            }
        }

        public void OnItemBreak(InventoryItem currentItem)
        {
            BreakItem?.Invoke(currentItem.Id);
        }

        protected override void OnShow()
        {
            Time.timeScale = 0;
        }

        protected override void OnHide()
        {
            Time.timeScale = 1;
        }

        private void OnCloseButtonClick()
        {
            Hide();
            _playerControlUi.Show();
            _indicatorsUi.Show();
            _itemControl.Hide();
        }

        private InventoryItem GetItem()
        {
            if (_itemsCounter <= 0)
            {
                var newItem = Instantiate(_inventoryItemPrefab, _itemsGridContentTransform);
                _loadedItems.Add(newItem);

                return newItem;
            }

            var item = _loadedItems[--_itemsCounter];
            item.transform.SetParent(_itemsGridContentTransform);
            item.gameObject.SetActive(true);

            return item;
        }
    }
}