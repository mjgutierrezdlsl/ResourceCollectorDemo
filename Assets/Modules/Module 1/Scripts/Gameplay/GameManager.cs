using DLSL.ResourceCollectorDemo.Core.Attributes;
using UnityEngine;

namespace DLSL.ResourceCollectorDemo.Gameplay
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameState _menuState, _pauseState, _gameActiveState;
        [SerializeField, ReadOnly] private GameState _currentState;

        public GameState CurrentState
        {
            get => _currentState;
            private set
            {
                _currentState = value;
                _currentState.Raise();
            }
        }
        private void Start()
        {
            ChangeState(_menuState);
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && _currentState != _menuState)
            {
                ChangeState(_currentState == _pauseState ? _gameActiveState : _pauseState);
            }
        }
        public void LoadAssets()
        {
            print("Loading Assets...");
            print("Load Complete!");
            ChangeState(_gameActiveState);
        }
        public void ChangeState(GameState newState)
        {
            CurrentState = newState;
        }
    }
}
