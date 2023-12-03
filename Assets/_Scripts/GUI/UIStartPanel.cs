using Root.Assets._Scripts.Gameplay;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Root.Assets._Scripts.GUI
{
    public class UIStartPanel : MonoBehaviour
    {
        [SerializeField] private Button _btnStart;
        [SerializeField] private Text _txtLevel;

        public void Init(GUIManager gUIManager, Game game)
        {
            _btnStart.onClick.AddListener(() =>
            {
                gUIManager.SetActiveStartPanel(false);
                gUIManager.SetActiveGameplayPanel(true);
                game.Run();
            });

            _txtLevel.text = "LEVEL " + game.CurrentLevelConfig.NumberLevel.ToString();
        }

        private void OnDisable()
        {
            _btnStart.onClick.RemoveAllListeners();
        }
    }
}