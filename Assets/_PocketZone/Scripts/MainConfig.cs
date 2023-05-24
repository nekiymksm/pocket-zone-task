using UnityEngine;

namespace _PocketZone.Scripts
{
    [CreateAssetMenu(fileName = "MainConfig", menuName = "Configs/MainConfig")]
    public class MainConfig : ScriptableObject
    {
        [SerializeField] private ModuleConfig[] _moduleConfigs;

        public T GetConfig<T>() where T : ModuleConfig
        {
            for (int i = 0; i < _moduleConfigs.Length; i++)
            {
                if (_moduleConfigs[i].GetType() == typeof(T))
                {
                    return _moduleConfigs[i] as T;
                }
            }
            
            Debug.LogError($"CONFIG_TYPE_OF_{typeof(T)}_NOT_SET");
            return null;
        }
    }
}