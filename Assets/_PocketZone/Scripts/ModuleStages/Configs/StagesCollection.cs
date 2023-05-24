using System;
using UnityEngine;

namespace _PocketZone.Scripts.ModuleStages.Configs
{
    public enum Stage
    {
        Test
    }
    
    [CreateAssetMenu(fileName = "StagesCollection ", menuName = "Configs/Modules/Stages/StagesCollection ")]
    public class StagesCollection : ScriptableObject
    {
        [SerializeField] private StageConfig[] _stageConfigs;

        public StageConfig GetConfig(Stage stage)
        {
            return _stageConfigs[(int)stage];
        }
    }

    [Serializable]
    public class StageConfig
    {
        [SerializeField] private int _enemiesCount;
        [SerializeField] private int _pickableItemsCount;
        
        public int EnemiesCount => _enemiesCount;
        public int PickableItemsCount => _pickableItemsCount;
    }
}