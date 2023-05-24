using UnityEngine;

namespace _PocketZone.Scripts.ModuleStages.Configs
{
    [CreateAssetMenu(fileName = "StagesModuleConfig", menuName = "Configs/Modules/Stages/StagesModuleConfig")]
    public class StagesModuleConfig : ModuleConfig
    {
        [SerializeField] private StagesCollection _stagesCollection;
        
        public StagesCollection StagesCollection => _stagesCollection;
    }
}