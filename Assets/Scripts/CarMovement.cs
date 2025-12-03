using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float speed = 5f;
    public Vector3 direction = Vector3.forward;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);   

        if (Mathf.Abs(transform.position.x) > 70f)
        {
            Destroy(gameObject);
        }
    }

    private void LeavesScreen()
    {
        Destroy(gameObject);
    }
}
