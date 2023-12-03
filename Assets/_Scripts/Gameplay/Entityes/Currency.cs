using UnityEngine;

namespace Root.Assets._Scripts.Gameplay.Entityes
{
    public class Currency : Entity, ICurrency
    {
        public int Score => _score;

        [SerializeField] private int _score;
        public override void Destroy()      
        {
            EffectsManager.Instance.ActiveEffectCurrency(transform.position);
            base.Destroy();
        }
    }
}