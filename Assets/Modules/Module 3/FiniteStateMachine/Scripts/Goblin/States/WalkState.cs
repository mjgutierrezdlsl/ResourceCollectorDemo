using System;
using UnityEngine;
namespace DLSL.ResourceCollectorDemo.Module3.FiniteStateMachine
{
    [Serializable]
    public class WalkState : State<GoblinStateMachine>
    {
        [SerializeField] private float _moveSpeed = 2f;
        [SerializeField] private float _distanceThreshold = 0.3f;
        [SerializeField] private Transform[] _waypoints;

        private Vector3 _targetPosition;
        private Vector3 _moveDirection;
        private int _waypointIndex;

        public WalkState(string name) : base(name)
        {
        }

        protected override void OnEnterState()
        {
            base.OnEnterState();
            Context.Animator.SetBool("isMoving", true);
            _targetPosition = _waypoints[_waypointIndex].position;
        }

        protected override void OnUpdateState()
        {
            base.OnUpdateState();

            _moveDirection = _targetPosition - Context.CurrentPosition;
            _moveDirection.Normalize();

            if (_moveDirection.x < 0)
            {
                Context.SpriteRenderer.flipX = true;
            }
            else if (_moveDirection.x > 0)
            {
                Context.SpriteRenderer.flipX = false;
            }

            if (Vector3.Distance(Context.CurrentPosition, _targetPosition) < _distanceThreshold)
            {
                Context.ChangeState(Context.Idle);
            }
        }

        protected override void OnPhysicsUpdateState()
        {
            base.OnPhysicsUpdateState();

            Context.Rigidbody2D.MovePosition(Context.CurrentPosition + _moveDirection * _moveSpeed * Time.fixedDeltaTime);
        }

        protected override void OnExitState()
        {
            base.OnExitState();

            _waypointIndex++;

            if (_waypointIndex >= _waypoints.Length)
            {
                _waypointIndex = 0;
            }
        }
    }

}