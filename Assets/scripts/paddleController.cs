using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 10f;      // Speed at which the paddle moves.
    public bool isPlayer1;         // Boolean to check if this paddle belongs to Player 1.

    private Rigidbody2D rb;        // Reference to the Rigidbody2D component for movement.
    private float minY, maxY;      // Boundaries for paddle movement.
    private float paddleHeight;    // Height of the paddle to adjust boundary calculations.

    private void Start()
    {
        // Get the Rigidbody2D component for movement control.
        rb = GetComponent<Rigidbody2D>();

        // Calculate the height of the paddle to properly account for boundary limits.
        paddleHeight = GetComponent<SpriteRenderer>().bounds.size.y / 2;

        // Set the boundaries based on the wall locations.
        minY = -3.8f + paddleHeight;  // Adjust this based on your wall's y-position (bottom wall).
        maxY = 3.8f - paddleHeight;   // Adjust this based on your wall's y-position (top wall).
    }

    private void Update()
    {
        // Get input from the correct axis for either Player 1 or Player 2.
        float moveInput = isPlayer1 ? Input.GetAxis("Vertical1") : Input.GetAxis("Vertical2");

        // Apply velocity to the paddle based on player input.
        rb.velocity = new Vector2(0, moveInput * speed);

        // Clamp the paddle's vertical position so it stays within the top and bottom boundaries.
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);

        // Apply the clamped position to the paddle.
        transform.position = new Vector2(transform.position.x, clampedY);
    }
}