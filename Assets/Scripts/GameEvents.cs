using UnityEngine;

public class GameEvents : MonoBehaviour
{
    // Creates delegate
    public delegate void SpaceAction();
    public static event SpaceAction ifSpacePressed;
    
// Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ifSpacePressed?.Invoke();
        }
    }
}
