using Root.Assets._Scripts.Core;
using Root.Assets._Scripts.Core.Config;
using Root.Assets._Scripts.Gameplay.Inputs;
using Root.Assets._Scripts.Gameplay.Player;
using Root.Assets._Scripts.Gameplay.Spawners;
using Root.Assets._Scripts.GUI;
using Root.Assets._Scripts.Tools;
using UnityEngine;

namespace Root.Assets._Scripts.Gameplay
{
    public class Game : MonoBehaviour
    {

        public LevelConfig CurrentLevelConfig { get; private set; }
        public LevelProgress GetLevelProgress => _levelProgress;
        public GameConfig GetGameConfig => _gameBootstrap.GetGameConfig;
        
        public LevelConfig[] Levels;

        [SerializeField] private PlayerModel _player;
        [SerializeField] private SpawnerManager _spawner;
        [SerializeField] private GUIManager _guiManager;
        
        private GameBootstrap _gameBootstrap;
        private IInputSystem _inputSystem;
        private LevelProgress _levelProgress;
        private GameStyleController _gameStyleController;
        private EffectsManager _effectsManager;

        public void Awake()
        {
            if (NeedGameBootstraping())
            {
                SceneLoader.Load(CodeScene.INIT_SCENE);
                return;
            }

            InitGameComponents();
            PreBuildLevel();
        }

        public void Run()
        {
            _spawner.Run();
        }

        private bool NeedGameBootstraping()
            => (_gameBootstrap = GameBootstrap.Instance) == null ? true : false;

        private void InitGameComponents()
        {
            CurrentLevelConfig = Levels[_gameBootstrap.GetGameConfig.NumberLevel - 1];

            _inputSystem = new BaseInputSystem();

            _levelProgress = new LevelProgress(_gameBootstrap.GetGameConfig, CurrentLevelConfig, _player);
            _gameStyleController = new GameStyleController(Camera.main);
            _effectsManager = new EffectsManager(_gameBootstrap.GetAssetsProvider);

            _player.Init(_inputSystem, CurrentLevelConfig);
            _spawner.Init(CurrentLevelConfig);
            _guiManager.Init(this);
        }

        private void PreBuildLevel()
        {
            _gameStyleController.Run();
        }
    }
}
