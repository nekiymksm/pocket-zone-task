using UnityEngine;

namespace _PocketZone.Scripts.ModuleUi.Configs
{
    [CreateAssetMenu(fileName = "UiModuleConfig", menuName = "Configs/Modules/Ui/UiModuleConfig")]
    public class UiModuleConfig : ModuleConfig
    {
        [SerializeField] private UiRoot _uiRootPrefab;

        public UiRoot UiRootPrefab => _uiRootPrefab;
    }
}