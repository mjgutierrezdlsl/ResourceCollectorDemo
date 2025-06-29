using System;
using DLSL.ResourceCollectorDemo.References;
using UnityEngine;
using UnityEngine.Events;

namespace DLSL.ResourceCollectorDemo.Gameplay
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] GameStateSetReference _gameStateReference;
        [SerializeField] GameState _startState;
        [field: SerializeField] public GameState CurrentState { get; private set; }

        private void Awake()
        {
            _gameStateReference.OnValueSet += OnGameStateSet;
        }
        private void OnDestroy()
        {
            _gameStateReference.OnValueSet -= OnGameStateSet;
        }
        private void Start()
        {
            _gameStateReference.SetValue(_startState);
        }
        private void OnGameStateSet(GameState state)
        {
            CurrentState = state;
        }
    }
}
