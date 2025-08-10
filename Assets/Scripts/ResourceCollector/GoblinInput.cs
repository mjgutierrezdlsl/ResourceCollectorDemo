using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DLSL.ResourceCollectorDemo
{
    public class GoblinInput : ControllerInput
    {
        InputSystem_Actions _input;

        private void Awake()
        {
            _input = new InputSystem_Actions();
            _input.Player.Enable();
        }
        private void OnEnable()
        {
            _input.Player.Move.performed += OnMovementPerformed;
            _input.Player.Move.canceled += OnMovementCanceled;
        }
        private void OnDisable()
        {
            _input.Player.Move.performed -= OnMovementPerformed;
            _input.Player.Move.canceled -= OnMovementCanceled;
        }

        private void OnMovementCanceled(InputAction.CallbackContext context)
        {
            Direction = Vector2.zero;
        }

        private void OnMovementPerformed(InputAction.CallbackContext context)
        {
            Direction = context.ReadValue<Vector2>();
        }

        private void OnDestroy()
        {
            _input.Player.Disable();
        }
    }
}
