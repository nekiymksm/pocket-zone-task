using System.Collections.Generic;
using _PocketZone.Scripts.ModuleItems.Configs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _PocketZone.Scripts.ModuleUi.UiElements
{
    public class IndicatorsUi : UiElement
    {
        [SerializeField] private TextMeshProUGUI _ammoValue;
        [SerializeField] private Image _healthBar;

        public void SetAmmoValue(int id, Dictionary<int, int> items)
        {
            if (id == (int)ItemKind.Ammo && items.TryGetValue((int)ItemKind.Ammo, out int count))
            {
                _ammoValue.SetText(count.ToString());
            }
        }

        public void SetHealthBar(float maxHealthValue)
        {
            _healthBar.fillAmount -= 1 / maxHealthValue;
        }
    }
}