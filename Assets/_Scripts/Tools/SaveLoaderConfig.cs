using Root.Assets._Scripts.Core.Config;
using UnityEngine;

namespace Root.Assets._Scripts.Tools
{
    public static class SaveLoaderConfig
    {
        private const string KEY_CONFIG = "circle_rush_config";

        public static void Save(GameConfig config)
        {
            string config_to_save = JsonUtility.ToJson(config);

            PlayerPrefs.SetString(KEY_CONFIG, config_to_save);
            PlayerPrefs.Save();
        }

        public static GameConfig Load()
        {

            if (!PlayerPrefs.HasKey(KEY_CONFIG))
                return new GameConfig();

            string config_to_load = PlayerPrefs.GetString(KEY_CONFIG);
            
            GameConfig config = JsonUtility.FromJson<GameConfig>(config_to_load);

            return config;
        }
    }
}
