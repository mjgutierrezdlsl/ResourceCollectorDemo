using System;
using UnityEngine;

namespace DLSL.ResourceCollectorDemo.Module4.FiniteStateMachine
{
    public abstract class State<T> where T : StateMachine<T>
    {
        private string _name;
        protected T Context;
        public State(string name)
        {
            _name = name;
        }
        public void Enter(StateMachine<T> context)
        {
            Context = context as T;
            OnEnterState();
        }

        public void Update()
        {
            OnUpdateState();
        }

        public void PhysicsUpdate()
        {
            OnPhysicsUpdateState();
        }

        public void Exit()
        {
            OnExitState();
        }

        protected virtual void OnEnterState() { }
        protected virtual void OnUpdateState() { }
        protected virtual void OnPhysicsUpdateState() { }
        protected virtual void OnExitState() { }

        public override string ToString()
        {
            return _name;
        }
    }
}
