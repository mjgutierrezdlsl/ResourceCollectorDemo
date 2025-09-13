using UnityEngine;

namespace DLSL.ResourceCollectorDemo.Module3.FiniteStateMachine
{
    public abstract class StateMachine<T> : MonoBehaviour where T : StateMachine<T>
    {
        protected State<T> CurrentState { get; private set; }
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
            if (CurrentState != null)
            {
                CurrentState.Exit();
            }
            CurrentState = newState;
            CurrentState.Enter(this);
        }
    }
}
