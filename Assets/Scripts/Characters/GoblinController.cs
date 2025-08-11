using UnityEngine;

namespace DLSL.ResourceCollectorDemo.Characters
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class GoblinController : CharacterHandler
    {
        private Rigidbody2D _rigidbody;
        protected override void Awake()
        {
            base.Awake();
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        public override void MoveCharacter(Vector2 inputDirection)
        {
            base.MoveCharacter(inputDirection);
            _rigidbody.MovePosition(_rigidbody.position + inputDirection * MovementSpeed * Time.deltaTime);
        }
    }
}
