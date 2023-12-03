using UnityEngine;

namespace Root.Assets._Scripts.Gameplay.Entityes
{
    [RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
    public abstract class Entity : MonoBehaviour, IEntityCollision
    {
        [SerializeField] protected float _speedMove;

        protected Rigidbody2D _rigidbody;

        public virtual void Init()
            => _rigidbody = GetComponent<Rigidbody2D>();

        public virtual void SetPosition(Vector2 position, Transform parent)
        {
            transform.position = position;
            transform.parent = transform;
        }

        public virtual void AddPush(Vector2 direction)
            => _rigidbody.velocity = direction * _speedMove;

        public virtual void Destroy()
            => gameObject.SetActive(false);
    }
}
