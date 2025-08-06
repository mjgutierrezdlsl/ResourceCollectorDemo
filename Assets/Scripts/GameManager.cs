using UnityEngine;
using DLSL.ResourceCollectorDemo.Resources;

namespace DLSL.ResourceCollectorDemo
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private ResourceSpawner[] _spawners;

        private void Start()
        {
            foreach (var spawner in _spawners)
            {
                spawner.SpawnResources(10);
            }
        }
    }
}
