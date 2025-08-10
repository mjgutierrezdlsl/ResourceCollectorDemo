using UnityEngine;

namespace DLSL.ResourceCollectorDemo
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class GoblinMovement : MonoBehaviour
    {
        [SerializeField] ControllerInput _input;
        Rigidbody2D _rigidbody;

        [SerializeField] float _movementSpeed = 5;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        private void FixedUpdate()
        {
            _rigidbody.MovePosition(_rigidbody.position + _input.Direction * _movementSpeed * Time.fixedDeltaTime);
        }
    }
}