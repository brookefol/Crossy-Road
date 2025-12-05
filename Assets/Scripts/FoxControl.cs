using UnityEngine;

public class FoxControl : MonoBehaviour
{
    // ----------------------- SINGLETON -----------------------
    public static FoxControl Instance;

    // ----------------------- MOVEMENT -------------------------
    public float baseSpeed = 8f;             // Starting speed
    public float sprintSpeedIncrement = 2f;  // Speed added each Shift press

    public Rigidbody rb;
    private Vector3 movement;

    // ----------------------- GAME STATE -----------------------
    public enum GameRunning{
        GameGoing,
        GameEnded,
        GameRestarting
    }

    private GameRunning gameStatus;

    private Vector3 startingPosition = new Vector3(0, 0, -50);

    // ----------------------- UNITY METHODS -----------------------
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody>();

        transform.position = startingPosition;
        gameStatus = GameRunning.GameGoing;
    }

    void Update()
    {
        if (gameStatus == GameRunning.GameGoing)
        {
            // ---------------- Movement Input ----------------
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            movement = new Vector3(moveHorizontal, 0f, moveVertical).normalized;

            // ---------------- Rotation ----------------
            if (movement.magnitude > 0.1f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(movement);
                rb.rotation = Quaternion.Slerp(rb.rotation, targetRotation, 0.15f);
            }

            // ---------------- SPEED STACKING (Shift) ----------------
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                baseSpeed += sprintSpeedIncrement;
                Debug.Log("Speed stacked! New speed = " + baseSpeed);
            }
        }

        // ---------------- Restart ----------------
        if (Input.GetKeyDown(KeyCode.R))
        {
            restartGame();
            gameStatus = GameRunning.GameGoing;
            Debug.Log("The game has begun anew");
        }
    }

    void FixedUpdate()
    {
        if (gameStatus == GameRunning.GameGoing)
        {
            rb.MovePosition(rb.position + movement * baseSpeed * Time.fixedDeltaTime);
        }
    }

    // Detect collisions with cars
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Car"))
        {
            Debug.Log("Game Over!");
            gameStatus = GameRunning.GameEnded;
            return;
        }
    }

    // ----------------------- GAME RESET -----------------------
    void restartGame()
    {
        gameStatus = GameRunning.GameRestarting;
        Debug.Log("Game Restarting");

        transform.position = startingPosition;
        rb.linearVelocity = Vector3.zero;

        baseSpeed = 8f; // Reset to default starting speed
    }
}
