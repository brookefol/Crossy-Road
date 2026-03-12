using System.Collections;
using UnityEngine;

public class CarSpawner : MonoBehaviour, ICarSpawner
{
    public GameObject carPrefab;
    public float spawnDelay = 1f;

    private SpawnProxy proxy;

    void Start()
    {
        proxy = new SpawnProxy(this);
        StartCoroutine(SpawnCarLoop());
    }

    private IEnumerator SpawnCarLoop()
    {
        while (true)
        {
            proxy.TrySpawn(Time.time);

            yield return new WaitForSeconds(spawnDelay);
        }
    }

    public void SpawnCar()
    {
        Instantiate(carPrefab, transform.position, transform.rotation);
    }
}