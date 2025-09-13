using UnityEngine;

namespace DLSL.ResourceCollectorDemo.Module3.AnimatorStateMachine
{
    public class WalkStateBehaviour : StateMachineBehaviour
    {
        [SerializeField] private float _moveSpeed = 2;
        [SerializeField] private float _distanceThreshold = 0.3f;
        private GoblinController _controller;
        private int _waypointIndex;
        private Transform _targetWaypoint;
        private Vector2 _direction;

        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _controller = animator.GetComponent<GoblinController>();
            if (_waypointIndex >= _controller.Waypoints.Length)
            {
                _waypointIndex = 0;
                _targetWaypoint = _controller.Waypoints[_waypointIndex];
            }
            _targetWaypoint = _controller.Waypoints[_waypointIndex];
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _direction = (_targetWaypoint.position - _controller.Position).normalized;
            if (_direction.x < 0)
            {
                _controller.SpriteRenderer.flipX = true;
            }
            else if (_direction.x > 0)
            {
                _controller.SpriteRenderer.flipX = false;
            }
            _controller.Rigidbody.MovePosition(_controller.Position + (Vector3)_direction * _moveSpeed * Time.fixedDeltaTime);
            if (Vector2.Distance(_controller.Position, _targetWaypoint.position) < _distanceThreshold)
            {
                animator.SetBool("isMoving", false);
            }
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _waypointIndex++;
        }
    }
}
