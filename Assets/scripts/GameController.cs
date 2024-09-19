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

    //Initializes the game by ensuring UI elements are assigned and displays the Start button.
    private void Start()
    {
        if (startButton == null || playAgainButton == null || winMessageText == null)
        {
            Debug.LogError("Start Button, Play Again Button, or Win Message Text is not assigned in the Inspector.");
            return;
        }

        ShowStartButton();  
    }

    //Displays the Start button and pauses the game until the player starts it.
    private void ShowStartButton()
    {
        if (startButton != null)
        {
            startButton.SetActive(true);  
        }

        if (playAgainButton != null)
        {
            playAgainButton.SetActive(false);  
        }

        if (winMessageText != null)
        {
            winMessageText.gameObject.SetActive(false);  
        }

       
        Time.timeScale = 0f;  
    }

    //Begins the game by hiding the Start button and resetting the ball and paddles.
    public void StartGame()
    {
        if (startButton != null)
        {
            startButton.SetActive(false);  
        }

        if (playAgainButton != null)
        {
            playAgainButton.SetActive(false);  
        }

        if (winMessageText != null)
        {
            winMessageText.gameObject.SetActive(false);  
        }

        
        Time.timeScale = 1f;  

        // Reset ball and paddles to their starting positions
        ResetBallAndPaddles();
    }

    // Resets the game to its initial state, including scores and positions.
    public void ResetGame()
    {
        
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ResetGame();
        }

      
        if (playAgainButton != null)
        {
            playAgainButton.SetActive(false);  
        }

        
        if (winMessageText != null)
        {
            winMessageText.text = "";  
            winMessageText.gameObject.SetActive(false);  
        }

        
        UpdateScoreUI(1, 0);  
        UpdateScoreUI(2, 0);  

        // Reset ball and paddles to their default positions
        ResetBallAndPaddles();

        
        Time.timeScale = 1f;  
    }

    // Resets the ball and paddles to their starting positions.
    private void ResetBallAndPaddles()
    {
       
        if (ball != null)
        {
            ball.transform.position = Vector2.zero;
        }

       
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

    // Updates the score UI for a specific player.
    public void UpdateScoreUI(int playerIndex, int score)
    {
        if (playerIndex == 1 && player1ScoreText != null)
        {
            player1ScoreText.text = score.ToString();  

        }
        else if (playerIndex == 2 && player2ScoreText != null)
        {
            player2ScoreText.text = score.ToString();  
        }
    }


    // Call this method when the game is over (e.g., when one player wins)
    public void GameOver(string winnerMessage)
    {
        if (playAgainButton != null)
        {
            playAgainButton.SetActive(true);  
        }

        if (winMessageText != null)
        {
            winMessageText.gameObject.SetActive(true);    
            winMessageText.text = winnerMessage;          
        }

        Time.timeScale = 0f;  
    }
}
