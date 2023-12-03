using System.Collections;
using UnityEngine;

namespace Root.Assets._Scripts.Gameplay.Effects
{
    [RequireComponent(typeof(ParticleSystem))]
    public class BaseEffect : MonoBehaviour, IEffect
    {
        [SerializeField] protected float _timePlaying;
        protected ParticleSystem _particleSystem;

        public void Run()
        {
            _particleSystem = GetComponent<ParticleSystem>();
            _particleSystem.Play();
            StartCoroutine(Destroying());
        }

        private IEnumerator Destroying()
        {
            yield return new WaitForSeconds(_timePlaying);
            Destroy(gameObject);
        }
    }
}
