using UnityEngine;

namespace Root.Assets._Scripts.Core.Config
{
    [CreateAssetMenu(fileName ="New level config", menuName ="CreateLevelConfig", order =10)]
    public class LevelConfig : ScriptableObject
    {
        public int TargetScore => _targetScore;
        public int NumberLevel => _numberLevel;
        public int CountElementsInPlayer => _countElementsInPlayer;
        public bool IsBonus => _isBonus;
        public float RateOfSpawn => _rateOfSpawn;
        public float PlayerSpeedRotation => _playerSpeedRotation;

        [Header("Level settings")]
        [SerializeField][Range(1, 256)] private int _targetScore;
        [SerializeField][Range(1, 100)] private int _numberLevel;
        [SerializeField] private bool _isBonus;

        [Header("Player settings")]
        [SerializeField] private float _playerSpeedRotation;
        [SerializeField][Range(1, 4)] private int _countElementsInPlayer;
        
        [Header("Spawner settings")]
        [SerializeField] private float _rateOfSpawn;
    }
}
