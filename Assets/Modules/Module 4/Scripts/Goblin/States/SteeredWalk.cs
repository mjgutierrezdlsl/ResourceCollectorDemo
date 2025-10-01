using UnityEngine;

namespace DLSL.ResourceCollectorDemo.Module4.FiniteStateMachine
{

    public class SteeredWalk : WalkState
    {
        public SteeredWalk(string name) : base(name)
        {
        }
        protected override void OnEnterState()
        {
            base.OnEnterState();
            Context.SteeringController.TargetPosition = _targetPosition;
        }
        protected override void OnUpdateState()
        {
            base.OnUpdateState();
            _moveDirection = Context.SteeringController.Direction;
        }
    }
}