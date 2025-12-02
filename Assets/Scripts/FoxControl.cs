using UnityEngine;

public class FoxControl : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody rb;  // Drag your Rigidbody here in Inspector

    private Vector3 movement;

    void Start()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get input
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        movement = new Vector3(moveHorizontal, 0f, moveVertical).normalized;

        // Rotate fox to face movement direction
        if (movement.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            rb.rotation = Quaternion.Slerp(rb.rotation, targetRotation, 0.15f);
        }
    }

    void FixedUpdate()
    {
        // Move the fox
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
