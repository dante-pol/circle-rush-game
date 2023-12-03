using UnityEngine;

namespace Root.Assets._Scripts.Gameplay.Entityes
{
    public interface ICurrency : IEntityCollision
    {
        int Score { get; }
    }
}