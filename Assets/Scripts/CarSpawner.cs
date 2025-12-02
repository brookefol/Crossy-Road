using System.Collections;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject carPrefab;
    public float spawnDelay = 1.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine("SpawnCarLoop");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnCarLoop()
    {
        for(;;)
        {
            SpawnCar();
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private void SpawnCar()
    {
        Instantiate(carPrefab, transform.position, transform.rotation);
    }
}
