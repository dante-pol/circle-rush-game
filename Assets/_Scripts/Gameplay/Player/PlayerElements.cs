using System;
using System.Xml.Linq;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

namespace Root.Assets._Scripts.Gameplay.Player
{
    public class PlayerElements
    {
        private readonly PlayerModel _player;
        
        private GameObject[] _elements;
        
        private int _countElements;

        public PlayerElements(PlayerModel player, int countElements, bool isShield = false)
        {
            _player = player;
            _elements = player.Elements;
            IsShield = isShield;
            _countElements = countElements;
            SetActiveElements(_elements.Length, false);

            //TODO: Clear
            SetActiveElements(_countElements, true);
        }

        public bool IsShield { get; set; }

        public void SetActiveElements(int count, bool isActive)
        {
            if (count < 0 || count > _elements.Length) return;

            for (int i = 0; i < count; i++)
            {
                _elements[i].SetActive(isActive);
            }
        }

        public void Dead()
        {
            for (int i = 0; i < _countElements; i++)
            {
                EffectsManager.Instance.ActiveEffectPlayerDead(_elements[i].transform.position);
            }
            _player.gameObject.SetActive(_player.gameObject);
        }
    }
}
