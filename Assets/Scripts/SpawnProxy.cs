public class SpawnProxy
{
    private ICarSpawner spawner;
    private float lastSpawnTime = 0f;
    private float minSpawnInterval = 0.8f;

    public SpawnProxy(ICarSpawner spawner)
    {
        this.spawner = spawner;
    }

    public void TrySpawn(float time)
    {
        if (time - lastSpawnTime >= minSpawnInterval)
        {
            lastSpawnTime = time;
            spawner.SpawnCar();
        }
    }
}