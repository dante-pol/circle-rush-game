using Root.Assets._Scripts.Core.Config;
using Root.Assets._Scripts.Gameplay.Entityes;
using Root.Assets._Scripts.Gameplay.Inputs;
using System;
using UnityEngine;

namespace Root.Assets._Scripts.Gameplay.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerModel : MonoBehaviour
    {
        public float SpeedRotation => _speedRotation;
        public Rigidbody2D Rigidbody => _rigidbody;
        public GameObject[] Elements => _elements;

        private float _speedRotation;
        [SerializeField] private GameObject[] _elements;

        private Rigidbody2D _rigidbody;
        private IInputSystem _inputSystem;
        private PlayerMovement _playerMovement;
        private PlayerElements _playerElements;

        private Action OnDead;
        private Action<int> OnCollectCurrency;

        public void Init(IInputSystem inputSystem, LevelConfig levelConfig)
        {
            _speedRotation = levelConfig.PlayerSpeedRotation;

            _inputSystem = inputSystem;

            _playerMovement = new PlayerMovement(this);
            _playerElements = new PlayerElements(this, levelConfig.CountElementsInPlayer);

            _rigidbody = GetComponent<Rigidbody2D>();

            AddListenerToDead(_playerElements.Dead);

        }

        private void Update()
        {
            if (_inputSystem.IsClick)
                _playerMovement.ChangeDirection();
        }

        private void FixedUpdate()
        {
            _playerMovement.FixedUpdate();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                IEntityCollision entity = collision.gameObject.GetComponent<Entity>();
                entity.Destroy();
                OnDead?.Invoke();
                //RemoveAllListenerToDead();
                //RemoveAllListenerToCollectCurrency();
            }
            else if (collision.gameObject.CompareTag("Currency"))
            {
                ICurrency currency = (ICurrency) collision.gameObject.GetComponent<Entity>();
                currency.Destroy();
                OnCollectCurrency?.Invoke(currency.Score);
            }
        }

        public void AddListenerToDead(Action callBack)
            => OnDead += callBack;

        public void RemoveAllListenerToDead()
            => OnDead = null;

        public void AddListenerToCollectCurrency(Action<int> callBack)
            => OnCollectCurrency += callBack;

        public void RemoveAllListenerToCollectCurrency()
            => OnCollectCurrency = null;
    }
}
