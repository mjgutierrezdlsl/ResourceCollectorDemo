using UnityEngine;
using UnityEngine.InputSystem;

namespace DLSL.ResourceCollectorDemo.Module2
{
    public class GoblinController : MonoBehaviour
    {
        [SerializeField]float _duration = 1f;
        Vector2 _targetPosition;
        float _moveSpeed = 2f;
        private void Start()
        {
            _targetPosition = Random.insideUnitCircle * 5f;
        }

        private void Update()
        {
            transform.position = Vector2.MoveTowards(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawSphere(_targetPosition, 0.1f);
        }

    }
}
