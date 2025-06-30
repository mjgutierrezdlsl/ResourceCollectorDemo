using DLSL.ResourceCollectorDemo.Gameplay;
using UnityEngine;
using UnityEngine.Events;

namespace DLSL.ResourceCollectorDemo
{
    public class GameStateListener : MonoBehaviour
    {
        [SerializeField] private GameState _state;
        [SerializeField] private UnityEvent _onStateActive;
        private void OnEnable()
        {
            _state.OnStateActive += OnStateActive;
        }
        private void OnDisable()
        {

            _state.OnStateActive -= OnStateActive;
        }
        private void OnStateActive()
        {
            _onStateActive?.Invoke();
        }
    }
}
