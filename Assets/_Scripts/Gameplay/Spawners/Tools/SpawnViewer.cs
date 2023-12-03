using UnityEditor;
using UnityEngine;

namespace Root.Assets._Scripts.Gameplay.Spawners.Tools
{
    public class SpawnViewer : MonoBehaviour
    {
        public float MaxAngle;
        public float MinAngle;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, (Vector2) transform.position + GetDirection(MinAngle));
            Gizmos.DrawLine(transform.position, (Vector2) transform.position + GetDirection(MaxAngle));
        }

        private Vector2 GetDirection(float angle)
        {
            float x = Mathf.Sin(angle * Mathf.Deg2Rad);
            float y = Mathf.Cos(angle * Mathf.Deg2Rad);
            return new Vector2(x, y);
        }
    }
}
