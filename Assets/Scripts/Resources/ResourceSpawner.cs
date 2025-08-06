using UnityEngine;

namespace DLSL.ResourceCollectorDemo.Resources
{
    public abstract class ResourceSpawner : MonoBehaviour
    {
        [field: SerializeField] public Resource Resource { get; private set; }
        public virtual void SpawnResources(int count)
        {
            print($"Spawned {count} resources");
        }
    }
}
