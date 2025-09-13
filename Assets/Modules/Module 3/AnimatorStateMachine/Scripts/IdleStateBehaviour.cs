using UnityEngine;

namespace DLSL.ResourceCollectorDemo.Module3.AnimatorStateMachine
{
    public class IdleStateBehaviour : StateMachineBehaviour
    {
        [SerializeField] private float _timeToWait = 1f;
        private float _elapsedTime;

        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (_elapsedTime < _timeToWait)
            {
                _elapsedTime += Time.deltaTime;
            }
            else
            {
                animator.SetBool("isMoving", true);
            }
        }

        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _elapsedTime = 0f;
        }
    }
}
