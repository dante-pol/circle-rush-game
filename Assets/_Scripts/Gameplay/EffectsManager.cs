using Root.Assets._Scripts.Core;
using Root.Assets._Scripts.Gameplay.Effects;
using UnityEngine;

namespace Root.Assets._Scripts.Gameplay
{
    public class EffectsManager
    {
        public static EffectsManager Instance { get; private set; }

        private BaseEffect _prefabEffectCurrency;
        private BaseEffect _prefabEffectPlayerDead;
        private BaseEffect _prefabEffectBonus;

        public EffectsManager(AssetsProvider assetsProvider)
        {
            if (Instance != null) return;

            Instance = this;
            _prefabEffectCurrency = assetsProvider.Load<BaseEffect>(AssetsProvider.PATH_TO_EFFECT_CURRENCY);
            _prefabEffectPlayerDead = assetsProvider.Load<BaseEffect>((AssetsProvider.PATH_TO_EFFECT_PLAYER_DEAD));
            _prefabEffectBonus = assetsProvider.Load<BaseEffect>((AssetsProvider.PATH_TO_EFFECT_BONUS));
        }

        public void ActiveEffectCurrency(Vector2 position)
        {
            IEffect effect = Object.Instantiate(_prefabEffectCurrency, position, Quaternion.Euler(90, 0, 0));
            effect.Run();
        }

        public void ActiveEffectPlayerDead(Vector2 position)
        {
            IEffect effect = Object.Instantiate(_prefabEffectPlayerDead, position, Quaternion.Euler(90, 0, 0));
            effect.Run();
        }

        internal void ActiveEffectBonus(Vector3 position)
        {
            IEffect effect = Object.Instantiate(_prefabEffectBonus, position, Quaternion.Euler(90, 0, 0));
            effect.Run();
        }
    }
}
