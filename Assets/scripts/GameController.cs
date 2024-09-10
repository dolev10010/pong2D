using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject startButton;      // Reference to Start Button
    public GameObject playAgainButton;  // Reference to Play Again Button
    public Text winMessageText;         // Reference to Win Message Text
    public GameObject ball;             // Reference to the Ball
    public GameObject[] paddles;        // References to the Paddles

    public Text player1ScoreText;  // Text UI for Player 1's score
    public Text player2ScoreText;  // Text UI for Player 2's score


    private void Start()
    {
        // Ensure that critical UI elements are assigned, otherwise log an error
        if (startButton == null || playAgainButton == null || winMessageText == null)
        {
            Debug.LogError("Start Button, Play Again Button, or Win Message Text is not assigned in the Inspector.");
            return;
        }

        ShowStartButton();  // Initially show the Start Button and hide others
    }

    private void ShowStartButton()
    {
        if (startButton != null)
        {
            startButton.SetActive(true);  // Show Start Button
        }

        if (playAgainButton != null)
        {
            playAgainButton.SetActive(false);  // Hide Play Again Button
        }

        if (winMessageText != null)
        {
            winMessageText.gameObject.SetActive(false);  // Hide win message at the start
        }

        // Pause the game
        Time.timeScale = 0f;  // Stop the game simulation
    }

    public void StartGame()
    {
        if (startButton != null)
        {
            startButton.SetActive(false);  // Hide Start Button when the game begins
        }

        if (playAgainButton != null)
        {
            playAgainButton.SetActive(false);  // Hide Play Again Button
        }

        if (winMessageText != null)
        {
            winMessageText.gameObject.SetActive(false);  // Hide the win message when the game starts
        }

        // Unpause the game
        Time.timeScale = 1f;  // Resume the game

        // Reset ball and paddles to their starting positions
        ResetBallAndPaddles();
    }

    public void ResetGame()
    {
        // Call GameManager's reset logic without causing a recursive loop
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ResetGame();
        }

        // Hide Play Again button after reset
        if (playAgainButton != null)
        {
            playAgainButton.SetActive(false);  // Hide the Play Again Button when resetting the game
        }

        // Reset and hide the win message
        if (winMessageText != null)
        {
            winMessageText.text = "";  // Reset the win message to an empty string
            winMessageText.gameObject.SetActive(false);  // Hide the win message
        }

        // Reset the score UI to 0 for both players
        UpdateScoreUI(1, 0);  // Reset Player 1's score display
        UpdateScoreUI(2, 0);  // Reset Player 2's score display

        // Reset ball and paddles to their default positions
        ResetBallAndPaddles();

        // Unpause the game
        Time.timeScale = 1f;  // Resume the game
    }

    private void ResetBallAndPaddles()
    {
        // Reset ball position
        if (ball != null)
        {
            ball.transform.position = Vector2.zero;
        }

        // Optionally reset paddles to their default position
        if (paddles != null)
        {
            foreach (GameObject paddle in paddles)
            {
                if (paddle != null)
                {
                    paddle.transform.position = new Vector2(paddle.transform.position.x, 0f);
                }
            }
        }
    }
    public void UpdateScoreUI(int playerIndex, int score)
    {
        if (playerIndex == 1 && player1ScoreText != null)
        {
            player1ScoreText.text = score.ToString();  // Update Player 1's score

        }
        else if (playerIndex == 2 && player2ScoreText != null)
        {
            player2ScoreText.text = score.ToString();  // Update Player 2's score
        }
    }


    // Call this method when the game is over (e.g., when one player wins)
    public void GameOver(string winnerMessage)
    {
        if (playAgainButton != null)
        {
            playAgainButton.SetActive(true);  // Show the Play Again button
        }

        if (winMessageText != null)
        {
            winMessageText.gameObject.SetActive(true);    // Show the win message
            winMessageText.text = winnerMessage;          // Set the win message text (e.g., "Player 1 Wins!")
        }

        // Pause the game
        Time.timeScale = 0f;  // Pause the game simulation
    }
}
