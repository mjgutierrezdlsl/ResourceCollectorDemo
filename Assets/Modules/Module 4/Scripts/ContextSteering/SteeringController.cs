using UnityEngine;

public class SteeringController : MonoBehaviour
{
    [SerializeField] private float _steerSpeed = 1f;
    [SerializeField] private float _viewRange = 1f;
    [SerializeField] private float _viewRadius = 0.1f;
    [SerializeField] private LayerMask _obstacleLayer = 1 << 6;
    public Vector3 Direction { get; set; }

    public Vector3 TargetPosition { get; set; }

    private void Update()
    {
        if (TargetPosition == null) return;

        Direction = (TargetPosition - transform.position).normalized;

        var hitInfo = Physics2D.CircleCast(transform.position, _viewRadius, Direction, _viewRange, _obstacleLayer);
        Debug.DrawRay(transform.position, Direction * _viewRange, Color.magenta);
        if (hitInfo)
        {
            Debug.DrawLine(hitInfo.point, hitInfo.normal.normalized, Color.cyan);
            print(Vector3.Dot(Direction, hitInfo.normal.normalized));
            Direction = Vector3.RotateTowards(transform.position, hitInfo.normal, _steerSpeed * Time.deltaTime, 0f);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _viewRange);
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position + (Direction * _viewRange), _viewRadius);
    }
}