using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    // Creates delegate
    public delegate void SpaceAction();
    public static SpaceAction IfSpacePressed;
    public static Action OnGameReset;
    public static Action OnGameOver;

    private static RealGameEvents realGameEvents;
    
    void Start()
    {
        realGameEvents = GetComponent<RealGameEvents>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IfSpacePressed?.Invoke();
        }
    }
    //referencing all the methods in the RealGameEvents
     public static void TriggerGameOver()
    {   
        realGameEvents.TriggerGameOver(); 
    }

     public static void TriggerGameReset()
    {     
        realGameEvents.TriggerGameReset();       
    }


}
