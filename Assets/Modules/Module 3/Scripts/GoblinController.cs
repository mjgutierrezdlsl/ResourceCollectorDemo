using UnityEngine;

namespace DLSL.ResourceCollector.Module3
{
    public class GoblinController : MonoBehaviour
    {
        [Header("Properties")]
        [SerializeField] private float _moveSpeed = 2f;

        [Header("Waypoint Navigation")]
        [SerializeField] private Transform[] _waypoints;
        private int _waypointIndex;
        private Transform _nextWaypoint;
        [SerializeField] private float _idleWaitTime = 1f;
        private float _idleElapsedTime;
        private bool _isMoving;
        [SerializeField] private float _distanceThreshold = 0.3f;
        private Vector2 _direction;

        private SpriteRenderer _spriteRenderer;
        private Rigidbody2D _rigidbody;
        private Animator _animator;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _animator = GetComponent<Animator>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        private void Start()
        {
            _nextWaypoint = _waypoints[1];
            transform.position = _waypoints[0].position;
        }

        private void Update()
        {
            if (Vector2.Distance(transform.position, _nextWaypoint.position) < _distanceThreshold)
            {
                if (_idleElapsedTime < _idleWaitTime)
                {
                    _idleElapsedTime += Time.deltaTime;
                    _isMoving = false;
                }
                else
                {
                    if (_waypointIndex >= _waypoints.Length - 1)
                    {
                        _nextWaypoint = _waypoints[0];
                        _waypointIndex = 0;
                    }
                    else
                    {
                        _waypointIndex++;
                        _nextWaypoint = _waypoints[_waypointIndex];
                    }
                    _idleElapsedTime = 0;
                }
            }
            else
            {
                _isMoving = true;
            }

            _direction = _nextWaypoint.position - transform.position;
            _direction.Normalize();

            _animator.SetBool("isMoving", _isMoving);

            if (_direction.x < 0)
            {
                _spriteRenderer.flipX = true;
            }
            else if (_direction.x > 0)
            {
                _spriteRenderer.flipX = false;
            }
        }

        private void FixedUpdate()
        {
            if (!_isMoving) return;
            _rigidbody.MovePosition(_rigidbody.position + _moveSpeed * Time.fixedDeltaTime * _direction);
        }
    }
}
