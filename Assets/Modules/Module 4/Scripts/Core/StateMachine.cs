using UnityEngine;

namespace DLSL.ResourceCollectorDemo.Module4.FiniteStateMachine
{
    public abstract class StateMachine<T> : MonoBehaviour where T : StateMachine<T>
    {
        protected State<T> CurrentState { get; private set; }

        public delegate void StateChangedEvent(State<T> prevState, State<T> newState);
        public event StateChangedEvent StateChanged;

        protected virtual void Update()
        {
            CurrentState.Update();
        }
        protected virtual void FixedUpdate()
        {
            CurrentState.PhysicsUpdate();
        }
        public void ChangeState(State<T> newState)
        {
            State<T> prevState = null;

            if (CurrentState != null)
            {
                CurrentState.Exit();
                prevState = CurrentState;
            }

            CurrentState = newState;
            CurrentState.Enter(this);

            StateChanged?.Invoke(prevState, CurrentState);
        }
    }
}
