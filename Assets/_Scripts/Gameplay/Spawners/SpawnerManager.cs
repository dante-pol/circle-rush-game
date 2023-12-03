using Root.Assets._Scripts.Core.Config;
using Root.Assets._Scripts.Gameplay.Entityes;
using Root.Assets._Scripts.Gameplay.Spawners.Tools;
using System.Collections;
using UnityEngine;

namespace Root.Assets._Scripts.Gameplay.Spawners
{
    public class SpawnerManager : MonoBehaviour
    {
        public bool IsSpawn;

        public float MinBorderX => _minBorderX;
        public float MaxBorderX => _maxBorderX;
        public float MaxBorderY => _maxBorderY;
        public float MinBorderY => _minBorderY;

        private int _currentCountSpawnEnemy;


        #region ObjectToSpawn
        [Header("Objects spawn")]
        [SerializeField] private Entity _prefabEnemy;
        [SerializeField] private Entity _prefabCurrency;
        [SerializeField] private Entity _prefabBonus;

        [Header("Spawner Defines")]
        [SerializeField] private SpawnCalculator[] _spawnDefines;
        #endregion

        #region SpawnerConfig
        [Header("Configuration")]
        [SerializeField] private int _minTimeBetweenSpawn;
        [SerializeField] private int _maxTimeBetweenSpawn;
        private float _rateOfSpawn;

        [Header("Border")]
        [SerializeField] private float _minBorderX;
        [SerializeField] private float _maxBorderX;
        [SerializeField] private float _maxBorderY;
        [SerializeField] private float _minBorderY;
        #endregion

        #region Spawners
        private Spawner _enemySpawner;
        private Spawner _currencySpawner;
        private Spawner _bonusSpawner;
        #endregion

        private LevelConfig _levelConfig;
        
        public void Init(LevelConfig levelConfig)
        {
            _rateOfSpawn = levelConfig.RateOfSpawn;

            _levelConfig = levelConfig;
            _enemySpawner = new Spawner(this, _prefabEnemy);
            _currencySpawner = new Spawner(this, _prefabCurrency);
            _bonusSpawner = new Spawner(this, _prefabBonus);
        }

        public void Run()
        {
            IsSpawn = true;
            StartCoroutine(Spawning());
        }

        public SpawnCalculator GetRandomSpawnDefine()
            => _spawnDefines[Random.Range(0, _spawnDefines.Length)];
        
        private IEnumerator Spawning()
        {
            _currentCountSpawnEnemy = Random.Range(_minTimeBetweenSpawn, _maxTimeBetweenSpawn);

            while (IsSpawn)
            {
                if (_currentCountSpawnEnemy == 0)
                {
                    if (_levelConfig.IsBonus)
                    {
                        if (Random.Range(0, 11) > 6)
                            _currencySpawner.Spawn();
                        else
                            _bonusSpawner.Spawn();
                    }
                    else
                    {
                        _currencySpawner.Spawn();
                    }
                    _currentCountSpawnEnemy = Random.Range(_minTimeBetweenSpawn, _maxTimeBetweenSpawn);
                }
                else
                {

                    _enemySpawner.Spawn();
                    _currentCountSpawnEnemy--;
                }
                
                yield return new WaitForSeconds(_rateOfSpawn);
            }
        }
    }
}
