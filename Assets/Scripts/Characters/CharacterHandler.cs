using UnityEngine;

namespace DLSL.ResourceCollectorDemo.Characters
{
    public abstract class CharacterHandler : MonoBehaviour
    {
        [field: SerializeField] public float MovementSpeed { get; protected set; }
        private SpriteRenderer _spriteRenderer;
        private Animator _animator;
        private bool _isFacingLeft;

        protected virtual void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _animator = GetComponent<Animator>();
        }

        public virtual void MoveCharacter(Vector2 inputDirection)
        {
            _animator.SetBool("isMoving", inputDirection != Vector2.zero);
            if (inputDirection.x < 0)
            {
                _isFacingLeft = true;
            }
            else if (inputDirection.x > 0)
            {
                _isFacingLeft = false;
            }
            _spriteRenderer.flipX = _isFacingLeft;
        }

        public virtual void Attack()
        {
            _animator.SetTrigger("attack");
        }
    }
}
