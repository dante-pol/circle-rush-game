using UnityEngine.SceneManagement;

namespace Root.Assets._Scripts.Tools
{
    public enum CodeScene { INIT_SCENE = 0, GAME_SCENE = 1}

    public static class SceneLoader
    {
        public static void Load(CodeScene code)
        {
            SceneManager.LoadScene((int)code);
        }
    }
}
