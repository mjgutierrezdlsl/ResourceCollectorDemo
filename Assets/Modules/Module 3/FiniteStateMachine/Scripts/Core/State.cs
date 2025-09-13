using System;
using UnityEngine;

namespace DLSL.ResourceCollectorDemo.Module3.FiniteStateMachine
{
    public abstract class State
    {
        private string _name;
        protected StateMachine Context;
        public State(string name)
        {
            _name = name;
        }
        public void Enter(StateMachine context)
        {
            Context = context;
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
