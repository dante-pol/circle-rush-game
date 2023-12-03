using UnityEngine;

namespace Root.Assets._Scripts.Core.Config
{
    public class GameConfig
    {
        public int NumberLevel { get; private set; }

        public GameConfig()
            => NumberLevel = 1;

        public void UpLevel()
            => NumberLevel++;
    }
}