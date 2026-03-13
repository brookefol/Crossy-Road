using UnityEngine;

public class FoxJump : MonoBehaviour
{
    private Rigidbody rb;
    private IJumpCondition jumpCondition; // ← injected

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpCondition = new GroundedCondition(rb); // ← swap condition here
    }

    private void OnEnable() => GameEvents.IfSpacePressed += Jump;
    private void OnDisable() => GameEvents.IfSpacePressed -= Jump;

    private void Jump()
    {
        if (jumpCondition.CanJump())
        {
            Debug.Log("Fox Jump!");
            // test
            rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }
    }
}