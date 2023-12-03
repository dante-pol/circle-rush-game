using UnityEngine;

namespace Root.Assets._Scripts.Gameplay.Spawners.Tools
{
    public interface ISpawnCalculator
    {
        Vector2 GetDirectionObjectToSpawn();
        Vector2 GetPositionObjectToSpawn();
    }
}