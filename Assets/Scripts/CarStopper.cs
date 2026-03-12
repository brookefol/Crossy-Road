using UnityEngine;
using System.Collections;

public class CarStopper : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private CarMovement car;

    void Awake()
    {
        car = GetComponent<CarMovement>();
    }

    
    private void OnEnable()
    {
        //adds the car to the subscriber list for OnGameOver
        GameEvents.OnGameOver += StopCar;
    }

    private void OnDisable()
    {
        GameEvents.OnGameOver -= StopCar;
    }

    void StopCar()
    {
        car.speed = 0f;
        StartCoroutine(ResetAfterDelay());
        
    }

    IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(3f);
        GameEvents.TriggerGameReset();
        Destroy(gameObject, 3f);
    }
   
}
