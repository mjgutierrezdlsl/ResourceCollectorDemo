namespace DLSL.ResourceCollectorDemo.Resources
{
    public class GoldSpawner : ResourceSpawner
    {
        public override void SpawnResources(int count)
        {
            base.SpawnResources(count);
            print("The spawned resources are Gold");
        }
    }
}
