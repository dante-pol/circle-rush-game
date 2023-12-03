using UnityEngine;

namespace Root.Assets._Scripts.Gameplay
{
    public class GameStyleController
    {
        private Color32[] _backgrounds;

        private Camera _camera;

        public GameStyleController(Camera camera)
        {
            _backgrounds = new Color32[]
            {
                new Color32(173, 216, 230, 255),
                new Color32(144, 238, 144, 255),
                new Color32(255, 182, 193, 255),
                new Color32(221, 160, 221, 255)
            };
            _camera = camera;
        }

        public void Run()
        {
            var index = Random.Range(0, _backgrounds.Length);
            _camera.backgroundColor = _backgrounds[index];
        }
    }
}
