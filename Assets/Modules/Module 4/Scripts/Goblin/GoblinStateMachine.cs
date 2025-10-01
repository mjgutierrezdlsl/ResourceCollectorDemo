using UnityEditor;
using UnityEngine;

namespace DLSL.ResourceCollectorDemo.Module4.FiniteStateMachine
{
    public class GoblinStateMachine : StateMachine<GoblinStateMachine>
    {
        [Header("Properties")]
        public Animator Animator { get; private set; }
        public SpriteRenderer SpriteRenderer { get; private set; }
        public Rigidbody2D Rigidbody2D { get; private set; }
        public SteeringController SteeringController { get; private set; }

        public Vector3 CurrentPosition => Rigidbody2D.position;

        [Header("States")]
        [field: SerializeField] public IdleState Idle { get; private set; } = new("Idle");
        [field: SerializeField] public WalkState Walk { get; private set; } = new SteeredWalk("Steered Walk");

        private void Awake()
        {
            Animator = GetComponent<Animator>();
            SpriteRenderer = GetComponent<SpriteRenderer>();
            Rigidbody2D = GetComponent<Rigidbody2D>();
            SteeringController = GetComponent<SteeringController>();
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