using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    // Creates delegate
    public delegate void SpaceAction();
    public static SpaceAction IfSpacePressed;
     public static event Action OnGameReset;
     public static event Action OnGameOver;
    
// Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IfSpacePressed?.Invoke();
        }
    }

    //announce to all subscriber that game is over /game is reset
     public static void TriggerGameOver()
    {
        // if (OnGameOver != null)
        // {
        //     foreach (Action subscriber in OnGameOver.GetInvocationList())
        //     {
        //         subscriber.Invoke();
        //     }
        // }
        OnGameOver?.Invoke();
        // for(int i = 0; i<100000; i++)
        // {
            
        // }
        //  Destroy(null, 3f);
        //  OnGameReset?.Invoke();
    }
     public static void TriggerGameReset()
    {
        // if (OnGameReset != null)
        // {
        //     foreach (Action subscriber in OnGameReset.GetInvocationList())
        //         subscriber.Invoke();
        // }

        OnGameReset?.Invoke();
        //  foreach (var car in GameObject.FindGameObjectsWithTag("Car"))
        // {
        //     Destroy(car);
        // }
    }


}
