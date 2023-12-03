using UnityEngine;

namespace Root.Assets._Scripts.Gameplay.Inputs
{
    public class BaseInputSystem : IInputSystem
    {
        private readonly KeyCode _keyToClick;

        public BaseInputSystem(KeyCode keyToClick = KeyCode.Space)
        {
            _keyToClick = keyToClick;
        }

        public virtual bool IsClick
        {
            get => Input.GetKeyDown(_keyToClick) ? true : false;
        }
    }
}
