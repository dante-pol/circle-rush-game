using Root.Assets._Scripts.Gameplay;
using Root.Assets._Scripts.Tools;
using System;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

namespace Root.Assets._Scripts.GUI
{
    public class UIGameWinPanel : MonoBehaviour
    {
        [SerializeField] private Button _btnNextLevel;
        [SerializeField] private Text _txtNextLevel;

        private Game _game;

        public void Init(GUIManager guiManager, Game game)
        {
            _game = game;

            _btnNextLevel.onClick.AddListener(() =>
            {
                SceneLoader.Load(CodeScene.GAME_SCENE);
            });
        }

        public void UpdateGUI()
        {
            _txtNextLevel.text = $"NEXT LEVEL {_game.GetGameConfig.NumberLevel}";
        }

        private void OnDisable()
        {
            _btnNextLevel.onClick.RemoveAllListeners();
        }
    }
}
