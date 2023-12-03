using Root.Assets._Scripts.Gameplay;
using UnityEngine;
using UnityEngine.UI;

namespace Root.Assets._Scripts.GUI
{
    public class UIGameplayPanel : MonoBehaviour
    {
        [SerializeField] private Text _txtLevel;
        [SerializeField] private Text _txtCurrentScore;
        [SerializeField] private Text _txtTargetScore;

        private Game _game;

        public void Init(GUIManager gUIManager, Game game)
        {
            _txtLevel.text = "LEVEL " + game.CurrentLevelConfig.NumberLevel.ToString();
            _txtCurrentScore.text = "0";
            _txtTargetScore.text = game.CurrentLevelConfig.TargetScore.ToString();

            _game = game;
            
            _game.GetLevelProgress.AddHandlerOnChangeProgress(UpdateGUI);
        }

        public void UpdateGUI()
        {
            _txtCurrentScore.text = _game.GetLevelProgress.Score.ToString();
        }

        
    }
}