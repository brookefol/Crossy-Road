public class SpawnProxy
{
    private ICarSpawner spawner;
    private float lastSpawnTime = 0f;
    private float minSpawnInterval = 0.4f;

    private bool canSpawn = true;

    

    public SpawnProxy(ICarSpawner spawner)
    {
        this.spawner = spawner;
        GameEvents.OnGameOver += StopSpawn;
        GameEvents.OnGameReset += ResetSpawn;
    }

    public void TrySpawn(float time)
    {
        if ((time - lastSpawnTime >= minSpawnInterval) && canSpawn)
        {
            lastSpawnTime = time;
            spawner.SpawnCar();
        }
    }
    private void StopSpawn()
    {
        canSpawn = false;
        
    }

    private void ResetSpawn()
    {
        canSpawn = true;
        lastSpawnTime = 0f;
        
    }
}