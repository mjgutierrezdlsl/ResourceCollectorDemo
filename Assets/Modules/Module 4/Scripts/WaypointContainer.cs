using System.Linq;
using UnityEngine;

namespace DLSL.ResourceCollectorDemo.Module4
{
    public class WaypointContainer : MonoBehaviour
    {
        [field: SerializeField] public Transform[] Waypoints { get; private set; }
        public int Length => Waypoints.Length;
        private void Reset()
        {
            Waypoints = GetComponentsInChildren<Transform>()
            .Where(t => t != transform) // Prevents the root transform from being included
            .ToArray();
        }
    }
}
