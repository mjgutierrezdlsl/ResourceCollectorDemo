using UnityEngine;

namespace DLSL.ResourceCollectorDemo.Module3.AnimatorStateMachine
{
    public class GoblinController : MonoBehaviour
    {
        [Header("Properties")]
        public Vector3 Position => Rigidbody.position;

        [Header("Waypoint Navigation")]
        [field: SerializeField] public Transform[] Waypoints { get; private set; }

        public SpriteRenderer SpriteRenderer { get; private set; }
        public Rigidbody2D Rigidbody { get; private set; }

        private void Awake()
        {
            SpriteRenderer = GetComponent<SpriteRenderer>();
            Rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            transform.position = Waypoints[0].position;
        }
    }
}
