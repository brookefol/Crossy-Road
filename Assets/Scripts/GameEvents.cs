using UnityEngine;

public class GameEvents : MonoBehaviour
{
    // Creates delegate
    public delegate void Action();
    public static Action ifSpacePressed;
    
// Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ifSpacePressed?.Invoke();
        }
    }
}
