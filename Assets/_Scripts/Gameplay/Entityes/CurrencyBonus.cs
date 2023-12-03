using UnityEngine;

namespace Root.Assets._Scripts.Gameplay.Entityes
{
    public class CurrencyBonus : Entity
    {
        public int Score => _score;

        [SerializeField] private int _score;

        public override void Destroy()
        {
            EffectsManager.Instance.ActiveEffectBonus(transform.position);
            base.Destroy();
        }
    }
}
