using UnityEngine;

namespace Root.Assets._Scripts.Gameplay.Spawners.Tools
{
    public class SpawnCalculator : MonoBehaviour, ISpawnCalculator
    {
        [SerializeField] private float MaxAngle;
        [SerializeField] private float MinAngle;
        public Vector2 GetPositionObjectToSpawn()
            => transform.position;

        public Vector2 GetDirectionObjectToSpawn()
        {
            float angle = Random.Range(MinAngle, MaxAngle + 1);
            float x = Mathf.Sin(angle * Mathf.Deg2Rad);
            float y = Mathf.Cos(angle * Mathf.Deg2Rad);
            return new Vector2(x, y);
        }
    }
}
