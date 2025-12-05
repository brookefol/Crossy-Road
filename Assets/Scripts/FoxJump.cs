using UnityEngine;

public class FoxJump : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //fox has rigid body
    }

    private void OnEnable()
    {
        GameEvents.IfSpacePressed += Jump; // jumps fox
    }
    
    private void OnDisable()
    {
        GameEvents.IfSpacePressed -= Jump;
    }
     
    private void Jump()
    {
        Debug.Log("Fox Jump!"); //Test that it works
        rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
    }
}
