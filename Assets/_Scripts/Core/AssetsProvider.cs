using UnityEngine;

namespace Root.Assets._Scripts.Core
{
    public class AssetsProvider
    {
        public static string PATH_TO_EFFECT_CURRENCY = "Effects/EffectCurrency";
        public static string PATH_TO_EFFECT_BONUS = "Effects/EffectBonus";
        public static string PATH_TO_EFFECT_PLAYER_DEAD = "Effects/EffectPlayerDead";

        public T Load<T>(string path) where T : Object
        {
            T resultObject = Resources.Load<T>(path);
            return resultObject;
        }
    }
}
