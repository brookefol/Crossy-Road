using System.Collections;
using UnityEngine;

public class CarSpawner : MonoBehaviour, ICarSpawner
{
    public GameObject carPrefab;
    public float spawnDelay = 1f;

    private ICarSpawner spawner;

    void Start()
    {
        proxy = new SpawnProxy(this);
        StartCoroutine(SpawnCarLoop());
    }

    private IEnumerator SpawnCarLoop()
    {
        while (true)
        {
            spawner.SpawnCar();

            yield return new WaitForSeconds(spawnDelay);
        }
    }

    public void SpawnCar()
    {
        Instantiate(carPrefab, transform.position, transform.rotation);
    }
}