using System;
using UnityEngine;

namespace DLSL.ResourceCollectorDemo.Gameplay
{
    [CreateAssetMenu(fileName = "GameState", menuName = "Gameplay/Game State")]
    public class GameState : ScriptableObject
    {
        public event Action OnStateActive;
        public void Raise() => OnStateActive?.Invoke();
    }
}
