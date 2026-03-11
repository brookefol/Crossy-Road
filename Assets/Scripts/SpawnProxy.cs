using UnityEngine;

public class SpawnProxy
{
    private float lastSpawnTime = 0f;
    private float minSpawnInterval = 2f;
    private bool allowSpawn = true;

     public SpawnProxy()
    {
        // Subscribe to Game Over and Game Reset
        GameEvents.OnGameOver += StopSpawn;
        GameEvents.OnGameReset += ResetSpawn;
    }

    public bool CanSpawn()
    {
        if (Time.time - lastSpawnTime >= minSpawnInterval && allowSpawn)
        {
            Debug.Log("Proxy: allowing spawn");

            lastSpawnTime = Time.time;
            return true;
        }
        Debug.Log("Proxy: blocking spawn");
        return false;
    }

    //stops and resets spawner when called
    public void StopSpawn()
    {
        allowSpawn = false;
    }

    public void ResetSpawn()
    {
        allowSpawn = true;
        lastSpawnTime = 0f;
    }
}