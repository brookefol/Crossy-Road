using UnityEngine;
using System;

public class RealGameEvents : MonoBehaviour
{
    // Creates delegate
    public delegate void SpaceAction();
    public static SpaceAction IfSpacePressed;
    public static Action OnGameReset;
    public static Action OnGameOver;

    //announce to all subscriber that game is over /game is reset
    public void TriggerGameOver()
    {
        
        OnGameOver?.Invoke();
       
    }
    public void TriggerGameReset()
    {
      

        OnGameReset?.Invoke();
        
    }


}
