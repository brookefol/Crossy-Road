using UnityEngine;

public class SpawnProxy
{
    private float lastSpawnTime = 0f;
    private float minSpawnInterval = 2f;

    public bool CanSpawn()
    {
        if (Time.time - lastSpawnTime >= minSpawnInterval)
        {
            Debug.Log("Proxy: allowing spawn");

            lastSpawnTime = Time.time;
            return true;
        }
        Debug.Log("Proxy: blocking spawn");
        return false;
    }
}