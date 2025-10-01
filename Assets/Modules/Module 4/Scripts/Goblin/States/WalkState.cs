using System;
using UnityEngine;
using Random = UnityEngine.Random;
namespace DLSL.ResourceCollectorDemo.Module4.FiniteStateMachine
{
    [Serializable]
    public class WalkState : State<GoblinStateMachine>
    {
        [SerializeField] private float _moveSpeed = 2f;
        [SerializeField] private float _distanceThreshold = 0.3f;
        [SerializeField] private WaypointContainer _waypoints;

        private Vector3 _targetPosition;
        private Vector3 _moveDirection;

        public WalkState(string name) : base(name)
        {
        }

        protected override void OnEnterState()
        {
            base.OnEnterState();
            Context.Animator.SetBool("isMoving", true);
            _targetPosition = _waypoints.Waypoints[Random.Range(0, _waypoints.Length)].position;
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
    }

}