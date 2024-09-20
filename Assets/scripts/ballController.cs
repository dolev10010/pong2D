using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 10f;       // Starting speed of the ball
    public float maxSpeed = 15f;
    public float minSpeed = 10f;

    private Rigidbody2D rb;
    private Vector2 initialVelocity;  // Cache to avoid creating new vectors every time

    // Initializes the Rigidbody2D component and starts the ball movement when the game begins.
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartBall();  
    }

    // Called every frame to ensure the ball's speed stays between the defined minimum and maximum limits.
    private void Update()
    {
        // Ensure the ball's speed stays between minSpeed and maxSpeed
        ClampBallSpeed();
    }

    // Start the ball moving when the game begins
      private void StartBall()
    {
       
        float directionX = Random.Range(0, 2) == 0 ? 1 : -1;
        float directionY = Random.Range(0, 2) == 0 ? 1 : -1;

        initialVelocity = new Vector2(speed * directionX, speed * directionY);
        rb.velocity = initialVelocity;
    }

    // Ensures the ball's speed is clamped between the minimum and maximum speed limits.
    private void ClampBallSpeed()
    {
        float currentSpeed = rb.velocity.magnitude;

        if (currentSpeed < minSpeed)
        {
            rb.velocity = rb.velocity.normalized * minSpeed;
        }
        else if (currentSpeed > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    // Handles the event when the ball enters a goal. Resets the ball and updates the score.
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Goal1"))  
        {
            GameManager.Instance.AddScore(2); 
            ResetBall();
        }
        else if (other.CompareTag("Goal2"))  
        {
            GameManager.Instance.AddScore(1);  
            ResetBall();
        }
    }

    // Resets the ball to the center of the screen and restarts its movement.
    private void ResetBall()
    {
        transform.position = Vector2.zero;
        StartBall();  
    }
}
