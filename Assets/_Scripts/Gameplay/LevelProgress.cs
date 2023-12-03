using Root.Assets._Scripts.Core.Config;
using Root.Assets._Scripts.Gameplay.Player;
using UnityEngine;
using UnityEngine.Events;

namespace Root.Assets._Scripts.Gameplay
{
    public class LevelProgress
    {
        public int Score { get; private set; }
        
        private readonly GameConfig _gameConfig;
        private readonly LevelConfig _levelConfig;

        private UnityAction OnChangeProgress;
        private UnityAction OnMakeProgress;

        public LevelProgress(GameConfig gameConfig, LevelConfig levelConfig, PlayerModel player)
        {
            _gameConfig = gameConfig;
            _levelConfig = levelConfig;

            player.AddListenerToCollectCurrency(IncreaseScore);
            AddHandlerOnMakeProgress(gameConfig.UpLevel);
        }

        public void IncreaseScore(int value)
        {
            Score += value;
            OnChangeProgress?.Invoke();

            if (Score >= _levelConfig.TargetScore)
            {
                OnMakeProgress?.Invoke();
                RemoveAllHandlersOnChangeProgress();
                RemoveAllHandlersOnMakeProgress();
            }

        }

        public void AddHandlerOnChangeProgress(UnityAction callBack)
            => OnChangeProgress += callBack;

        public void RemoveAllHandlersOnChangeProgress()
            => OnChangeProgress = null;

        public void AddHandlerOnMakeProgress(UnityAction callBack)
            => OnMakeProgress += callBack;

        public void RemoveAllHandlersOnMakeProgress()
            => OnMakeProgress = null;
    }
}
