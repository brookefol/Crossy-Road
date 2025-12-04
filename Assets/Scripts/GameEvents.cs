using UnityEngine;

public class GameEvents : MonoBehaviour
{
    // Creates delegate
    public delegate void SpaceAction();
    public static SpaceAction IfSpacePressed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IfSpacePressed?.Invoke();
        }
    }
}
