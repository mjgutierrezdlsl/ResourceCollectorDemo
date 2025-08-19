using UnityEngine;

namespace DLSL.ResourceCollectorDemo.Resources
{
    public class GoldSpawner : ResourceSpawner
    {
        [SerializeField] float _spawnRadius;
        private void Update()
        {
            transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * 2f * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SpawnResources(5);    
            }    
        }

        public override void SpawnResources(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var spawnPosition =(Vector2)transform.position + Random.insideUnitCircle * _spawnRadius;
                Instantiate(this.Resource, spawnPosition, Quaternion.identity);
            }
        }
        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, _spawnRadius);
        }
    }
}
