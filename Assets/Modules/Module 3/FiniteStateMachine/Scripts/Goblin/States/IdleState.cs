using System;
using UnityEngine;

namespace DLSL.ResourceCollectorDemo.Module3.FiniteStateMachine
{
    [Serializable]
    public class IdleState : State
    {
        private GoblinStateMachine _context;
        [SerializeField] private float _waitTime = 1f;
        private float _elapsedTime;
        public IdleState(string name) : base(name)
        {
        }
        protected override void OnEnterState()
        {
            base.OnEnterState();
            _context = (GoblinStateMachine)Context;
            _context.Animator.SetBool("isMoving", false);
        }
        protected override void OnUpdateState()
        {
            base.OnUpdateState();
            if (_elapsedTime < _waitTime)
            {
                _elapsedTime += Time.deltaTime;
            }
            else
            {
                _context.ChangeState(_context.Walk);
            }
        }
        protected override void OnExitState()
        {
            base.OnExitState();
            _elapsedTime = 0f;
        }
    }
}