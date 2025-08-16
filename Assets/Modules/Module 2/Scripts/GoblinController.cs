using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DLSL.ResourceCollectorDemo.Module2
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class GoblinController : MonoBehaviour
    {
        [SerializeField] float _moveSpeed = 2f;
        [SerializeField] float _jumpForce = 10f;
        InputSystem_Actions _inputs ;
        private Rigidbody2D _rigidbody;
        private Vector2 _direction;
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _inputs = new();
            _inputs.Player.Enable();
                    }

        private void OnDestroy()
        {
            _inputs.Player.Disable();
        }

        private void Update()
        {
            _direction = _inputs.Player.Move.ReadValue<Vector2>();
        }

        private void FixedUpdate()
        {
            _rigidbody.MovePosition(_rigidbody.position + _direction * _moveSpeed * Time.deltaTime);
        }
    }
}
