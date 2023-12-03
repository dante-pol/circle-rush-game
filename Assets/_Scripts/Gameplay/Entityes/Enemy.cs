using UnityEngine;

namespace Root.Assets._Scripts.Gameplay.Entityes
{

    public class Enemy : Entity
    {
        public override void Destroy()
        {
            EffectsManager.Instance.ActiveEffectPlayerDead(transform.position);
            base.Destroy();
        }
    }
}
