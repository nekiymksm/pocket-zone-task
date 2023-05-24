using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _PocketZone.Scripts.ModuleUi.UiElements
{
    public class PlayerControlUi : UiElement
    {
        [SerializeField] private Joystick _joystick;
        [SerializeField] private Button _shootButton;
        [SerializeField] private Button _inventoryButton;
        [SerializeField] private bool _hasKeyboard;

        private InventoryUi _inventoryUi;
        private IndicatorsUi _indicatorsUi;

        public event Action ShotButtonClick;
        public event Action InventoryButtonClick;

        [Inject]
        private void Construct(UiRoot uiRoot)
        {
            _inventoryUi = uiRoot.GetUiElement<InventoryUi>();
            _indicatorsUi = uiRoot.GetUiElement<IndicatorsUi>();
        }
        
        private void Awake()
        {
            _shootButton.onClick.AddListener(OnShootButtonClick);
            _inventoryButton.onClick.AddListener(OnInventoryButtonClick);
        }

        private void OnDestroy()
        {
            _shootButton.onClick.RemoveListener(OnShootButtonClick);
            _inventoryButton.onClick.RemoveListener(OnInventoryButtonClick);
        }

        public Vector3 GetMoveDirection()
        {
            var horizontal = _hasKeyboard ? Input.GetAxisRaw("Horizontal") : _joystick.Horizontal;
            var vertical = _hasKeyboard ? Input.GetAxisRaw("Vertical") : _joystick.Vertical;
            
            return new Vector2(horizontal, vertical);
        }

        private void OnShootButtonClick()
        {
            ShotButtonClick?.Invoke();
        }

        private void OnInventoryButtonClick()
        {
            Hide();
            _indicatorsUi.Hide();
            _inventoryUi.Show();
            
            InventoryButtonClick?.Invoke();
        }
    }
}