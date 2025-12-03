using UnityEngine;

public class FoxControl : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody rb;  // Drag your Rigidbody here in Inspector

    private Vector3 movement;

    public enum GameRunning{
        GameGoing,
        GameEnded,
        GameRestarting
    }

    private GameRunning gameStatus;

    private Vector3 startingPosition = new Vector3(0, 0, -50);

    void Start()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody>();
        transform.position = startingPosition;
        gameStatus = GameRunning.GameGoing;

    }

    void Update()
    {
        if(gameStatus == GameRunning.GameGoing){
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

        //if r is pressed the game restarts
        if(Input.GetKeyDown(KeyCode.R)){
            restartGame();
            gameStatus = GameRunning.GameGoing;
            Debug.Log("The game has begun anew");
        }

    }

    void FixedUpdate()
    {
        if(gameStatus == GameRunning.GameGoing){
            // Move the fox
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        }
    }

    //if the fox collides with a car the game ends
    void OnCollisionEnter(Collision collision){
        if (collision.collider.CompareTag("Car"))
        {
            Debug.Log("Game Over!");
            gameStatus = GameRunning.GameEnded;
        }
    }

    //helper method to actually restart the game
    void restartGame(){
        gameStatus = GameRunning.GameRestarting;
        Debug.Log("Game Restarting");
        transform.position = startingPosition;
    }


}
