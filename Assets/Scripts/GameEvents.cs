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
        
        OnGameOver?.Invoke();
       
    }
     public static void TriggerGameReset()
    {
      

        OnGameReset?.Invoke();
        
    }


}
