using UnityEngine;

namespace DLSL.ResourceCollectorDemo.Characters
{
    public class TNTController : CharacterHandler
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
            _rigidbody.AddForce(MovementSpeed * inputDirection);
        }
    }
}
