using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int player1Score = 0;  // Tracks Player 1's score
    public int player2Score = 0;  // Tracks Player 2's score
    public int maxScore = 5;      // The score required to win the game

    private void Awake()
    {
        // Singleton pattern to ensure only one GameManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Keep the GameManager persistent between scenes
        }
        else
        {
            Destroy(gameObject);  // Avoid duplicates
        }
    }

    // Reset game-specific data (like scores) at the start of a new game
    public void ResetGame()
    {
        player1Score = 0;
        player2Score = 0;
        Debug.Log("GameManager: Game state reset.");
    }

    // Update score for a specific player
    public void AddScore(int playerIndex)
{
    if (playerIndex == 1)
    {
        player1Score++;
        FindObjectOfType<GameController>().UpdateScoreUI(1, player1Score);  // Update Player 1's score in the UI
    }
    else if (playerIndex == 2)
    {
        player2Score++;
        FindObjectOfType<GameController>().UpdateScoreUI(2, player2Score);  // Update Player 2's score in the UI
    }

    // Check for a winner
    CheckForWin();
}


    // Check if any player has won the game
    private void CheckForWin()
    {
        if (player1Score >= maxScore)
        {
            // Player 1 wins
            FindObjectOfType<GameController>().GameOver("Player 1 Wins!");
        }
        else if (player2Score >= maxScore)
        {
            // Player 2 wins
            FindObjectOfType<GameController>().GameOver("Player 2 Wins!");
        }
    }
}

