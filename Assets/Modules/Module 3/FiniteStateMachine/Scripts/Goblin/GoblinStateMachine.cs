using UnityEditor;
using UnityEngine;

namespace DLSL.ResourceCollectorDemo.Module3.FiniteStateMachine
{
    public class GoblinStateMachine : StateMachine<GoblinStateMachine>
    {
        private float health;

        [Header("Properties")]
        public Animator Animator { get; private set; }
        public SpriteRenderer SpriteRenderer { get; private set; }
        public Rigidbody2D Rigidbody2D { get; private set; }

        public Vector3 CurrentPosition => Rigidbody2D.position;

        [field: SerializeField] public float MaxHealth { get; private set; } = 5f;
        public float Health
        {
            get => health;
            set
            {
                health = value;
                if (health <= 0)
                {
                    health = 0;
                }
            }
        }


        [Header("States")]
        [field: SerializeField] public IdleState Idle { get; private set; } = new("Calm Idle");
        [field: SerializeField] public WalkState Walk { get; private set; } = new("Calm Walk");
        [field: SerializeField] public EnragedWalkState EnragedWalk { get; private set; } = new("Enraged Walk");
        [field: SerializeField] public DeathState Dead { get; private set; } = new("Dead");

        private void Awake()
        {
            Animator = GetComponent<Animator>();
            SpriteRenderer = GetComponent<SpriteRenderer>();
            Rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            Health = MaxHealth;
            ChangeState(Idle);
        }
        protected override void Update()
        {
            base.Update();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Health--;
            }
        }
        private void OnDrawGizmosSelected()
        {
#if UNITY_EDITOR
            Handles.Label(transform.position + Vector3.up, $"State: {CurrentState}");
            Handles.Label(transform.position + Vector3.up * 1.5f, $"Health: {Health}");
#endif
        }
    }
}