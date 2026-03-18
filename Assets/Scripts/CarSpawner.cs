using System.Collections;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject carPrefab;
    public float spawnDelay = 1f;

    private bool canSpawn = true;

    void Start()
    {
        StartCoroutine("SpawnCarLoop");
    }

    private IEnumerator SpawnCarLoop()
    {
        for(;;)
        {
            SpawnCar();
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    public void SpawnCar()
    {
        Instantiate(carPrefab, transform.position, transform.rotation);
        GameEvents.OnGameOver += StopSpawn;
        GameEvents.OnGameReset += ResetSpawn;
    }

    private void StopSpawn()
    {
        canSpawn = false;
        
    }

    private void ResetSpawn()
    {
        canSpawn = true;
    }
}