using Root.Assets._Scripts.Core.Config;
using Root.Assets._Scripts.Gameplay;
using UnityEngine;

namespace Root.Assets._Scripts.GUI
{
    public class GUIManager : MonoBehaviour
    {
        [SerializeField] private UIStartPanel _startPanel;
        [SerializeField] private UIGameplayPanel _gameplayPanel;
        [SerializeField] private UIGameOverPanel _gameOverPanel;
        [SerializeField] private UIGameWinPanel _gameWinPanel;

        public void Init(Game game)
        {
            _startPanel.Init(this, game);
            _gameplayPanel.Init(this, game);
            _gameOverPanel.Init(this, game);
            _gameWinPanel.Init(this, game);

            game.GetLevelProgress.AddHandlerOnMakeProgress(() =>
            {
                SetActiveGameWinPanel(true);
                SetActiveGameplayPanel(false);
                _gameWinPanel.UpdateGUI();
            });

            ResetActiveAllPanels();

            SetActiveStartPanel(true);
        }

        public void ResetActiveAllPanels()
        {
            SetActiveStartPanel(false);
            SetActiveGameplayPanel(false);
            SetActiveGameOverPanel(false);
            SetActiveGameWinPanel(false);
        }


        public void SetActiveStartPanel(bool value)
            => _startPanel.gameObject.SetActive(value);

        public void SetActiveGameplayPanel(bool value)
            => _gameplayPanel.gameObject.SetActive(value);

        public void SetActiveGameOverPanel(bool value)
            => _gameOverPanel.gameObject.SetActive(value);

        public void SetActiveGameWinPanel(bool value)
            => _gameWinPanel.gameObject.SetActive(value);
    }
}
