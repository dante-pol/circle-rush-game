using Root.Assets._Scripts.Core.Config;
using Root.Assets._Scripts.Tools;
using System;
using UnityEngine;

namespace Root.Assets._Scripts.Core
{
    public class GameBootstrap : MonoBehaviour
    {
        public static GameBootstrap Instance { get; private set; }

        public GameConfig GetGameConfig { get; private set; }

        public AssetsProvider GetAssetsProvider { get; private set; }

        private void Start()
        {
            if (!NeedGameBootstraping()) return;

            Instance = this;
            DontDestroyOnLoad(gameObject);

            LoadConfig();

            LoadGame();
        }

        private bool NeedGameBootstraping()
            => Instance == null ? true : false;

        private void LoadGame()
            => SceneLoader.Load(CodeScene.GAME_SCENE);

        private void LoadConfig()
        {
            GetGameConfig = SaveLoaderConfig.Load();
            GetAssetsProvider = new AssetsProvider();
        }
    }
}
