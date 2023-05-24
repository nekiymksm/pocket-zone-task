using UnityEngine;

namespace _PocketZone.Scripts.ModuleUi
{
    public class UiRoot : MonoBehaviour
    {
        [SerializeField] private UiElement[] _uiElements;

        public T GetUiElement<T>() where T : UiElement
        {
            for (int i = 0; i < _uiElements.Length; i++)
            {
                if (_uiElements[i].GetType() == typeof(T))
                {
                    return _uiElements[i] as T;
                }
            }

            return null;
        }
    }
}