using Root.Assets._Scripts.Gameplay.Entityes;
using Root.Assets._Scripts.Gameplay.Spawners.Tools;
using UnityEngine;

namespace Root.Assets._Scripts.Gameplay.Spawners
{
    public class Spawner
    {
        private readonly SpawnerManager _manager;
        private readonly Entity _prefabToSpawn;

        public Spawner(SpawnerManager spawnerManager, Entity prefab)
        {
            _manager = spawnerManager;
            _prefabToSpawn = prefab;
        }

        public void Spawn()
        {
            ISpawnCalculator calculator = _manager.GetRandomSpawnDefine();
            var enemy = CreateEnemy();

            enemy.Init();
            enemy.SetPosition(calculator.GetPositionObjectToSpawn(), _manager.transform);
            enemy.AddPush(calculator.GetDirectionObjectToSpawn());
        }

        private Entity CreateEnemy()
        {
            return Object.Instantiate(_prefabToSpawn);
        }
    }
}
