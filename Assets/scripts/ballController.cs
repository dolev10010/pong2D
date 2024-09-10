using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 10f;       // Starting speed of the ball
    public float maxSpeed = 15f;    // Maximum speed of the ball
    public float minSpeed = 10f;    // Minimum speed of the ball

    private Rigidbody2D rb;
    private Vector2 initialVelocity;  // Cache to avoid creating new vectors every time

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartBall();  // Start the ball moving when the game begins
    }

    private void Update()
    {
        // Ensure the ball's speed stays between minSpeed and maxSpeed
        ClampBallSpeed();
    }

    private void StartBall()
    {
        // Set a random direction for the ball
        float directionX = Random.Range(0, 2) == 0 ? 1 : -1;
        float directionY = Random.Range(0, 2) == 0 ? 1 : -1;

        // Apply initial velocity and cache the result to avoid re-allocating new vectors
        initialVelocity = new Vector2(speed * directionX, speed * directionY);
        rb.velocity = initialVelocity;
    }

    private void ClampBallSpeed()
    {
        // Get the current speed (magnitude) of the ball's velocity
        float currentSpeed = rb.velocity.magnitude;

        // Only update the velocity if it's outside the allowed range
        if (currentSpeed < minSpeed)
        {
            rb.velocity = rb.velocity.normalized * minSpeed;
        }
        else if (currentSpeed > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Detect if the ball enters the goals (behind the paddles)
        if (other.CompareTag("Goal1"))  // This is Player 1's goal, Player 2 scores
        {
            GameManager.Instance.AddScore(2);  // Player 2 scores a point
            ResetBall();
        }
        else if (other.CompareTag("Goal2"))  // This is Player 2's goal, Player 1 scores
        {
            GameManager.Instance.AddScore(1);  // Player 1 scores a point
            ResetBall();
        }
    }

    private void ResetBall()
    {
        // Reset ball's position and restart movement
        transform.position = Vector2.zero;
        StartBall();  // Restart the ball movement
    }
}
