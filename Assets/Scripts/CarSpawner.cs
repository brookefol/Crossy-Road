using System.Collections;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject carPrefab;
    public float spawnDelay = 1f;

    private SpawnProxy proxy = new SpawnProxy();


    void Start()
    {
        StartCoroutine(SpawnCarLoop());
    }

    private IEnumerator SpawnCarLoop()
    {
        for (;;)
        {
            if (proxy.CanSpawn())
            {
                SpawnCar();
            }

            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private void SpawnCar()
    {
        Instantiate(carPrefab, transform.position, transform.rotation);
    }


}