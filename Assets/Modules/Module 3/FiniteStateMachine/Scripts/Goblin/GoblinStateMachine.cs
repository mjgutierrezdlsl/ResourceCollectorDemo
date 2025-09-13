using UnityEditor;
using UnityEngine;

namespace DLSL.ResourceCollectorDemo.Module3.FiniteStateMachine
{
    public class GoblinStateMachine : StateMachine
    {
        [Header("Properties")]
        public Animator Animator { get; private set; }

        [Header("States")]
        [field: SerializeField] public IdleState Idle { get; private set; } = new("Idle");
        public WalkState Walk = new("Walk");
        private void Awake()
        {
            Animator = GetComponent<Animator>();
        }
        private void Start()
        {
            ChangeState(Idle);
        }

        private void OnDrawGizmosSelected()
        {
#if UNITY_EDITOR
            Handles.Label(transform.position + Vector3.up, $"State: {CurrentState}");
#endif
        }
    }
}