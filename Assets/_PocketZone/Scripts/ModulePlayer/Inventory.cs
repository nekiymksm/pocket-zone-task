using System.Collections.Generic;
using _PocketZone.Scripts.ModuleItems;
using _PocketZone.Scripts.ModuleUi;
using _PocketZone.Scripts.ModuleUi.UiElements;
using UnityEngine;
using Zenject;

namespace _PocketZone.Scripts.ModulePlayer
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class Inventory : MonoBehaviour
    {
        private InventoryUi _inventoryUi;
        private IndicatorsUi _indicatorsUi;

        public Dictionary<int, int> Items { get; private set; }

        [Inject]
        private void Construct(UiRoot uiRoot)
        {
            _inventoryUi = uiRoot.GetUiElement<InventoryUi>();
            _indicatorsUi = uiRoot.GetUiElement<IndicatorsUi>();
            
            _inventoryUi.BreakItem += BreakItem;
        }

        private void Awake()
        {
            Items = new Dictionary<int, int>();
        }

        private void OnDestroy()
        {
            _inventoryUi.BreakItem -= BreakItem;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.TryGetComponent(out PickableItem item))
            {
                PutItem(item.Id);
                item.Hide();
            }
        }

        public void Show()
        {
            _inventoryUi.Set(Items);
        }

        public void PutItem(int id)
        {
            int itemsValue = 1;
            
            if (Items.TryGetValue(id, out int itemsCount))
            {
                itemsValue += itemsCount;
                Items.Remove(id);
            }
            
            Items.Add(id, itemsValue);
            _indicatorsUi.SetAmmoValue(id, Items);
        }

        public void BreakItem(int id)
        {
            Items.TryGetValue(id, out int itemsCount);
            int itemsValue = itemsCount - 1;
            
            Items.Remove(id);
            
            if (itemsValue > 0)
            {
                for (int i = 0; i < itemsValue; i++)
                {
                    PutItem(id);
                }
            }
            
            _inventoryUi.Set(Items);
            _indicatorsUi.SetAmmoValue(id, Items);
        }
    }
}