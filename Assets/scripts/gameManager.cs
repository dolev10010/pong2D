using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int player1Score = 0;  // Tracks Player 1's score
    public int player2Score = 0;  // Tracks Player 2's score
    public int maxScore = 5;      // The score required to win the game

    private AudioSource audioSource;  // Private reference to the AudioSource component
    public AudioClip scoreSound;      // Public reference to the sound clip played on score
    public AudioClip winSound;        // Public reference to the sound clip played on win

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
            return;
        }

        // Get the AudioSource component attached to the GameManager GameObject
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is missing from GameManager!");
        }
    }

    // Reset game-specific data (like scores) at the start of a new game
    public void ResetGame()
    {
        player1Score = 0;
        player2Score = 0;
    }

    // This method starts the coroutine that handles the delay after a player scores
    public void AddScore(int playerIndex)
    {
        // Start the coroutine to handle the score delay
        StartCoroutine(ScoreWithDelay(playerIndex));
    }

    // Coroutine to handle delay after scoring
    private IEnumerator ScoreWithDelay(int playerIndex)
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

        // Play the score sound
        if (audioSource != null && scoreSound != null)
        {
            audioSource.PlayOneShot(scoreSound);  // Play the score sound when a player scores
        }

        // Add a 0.5-second delay before checking for the win
        yield return new WaitForSeconds(0.5f);

        // Check for a winner after the delay
        CheckForWin();
    }

    // Check if any player has won the game
    private void CheckForWin()
    {
        if (player1Score >= maxScore)
        {
            // Play the winning sound for Player 1
            PlayWinningSound();

            // Player 1 wins
            FindObjectOfType<GameController>().GameOver("Player 1 Wins!");
        }
        else if (player2Score >= maxScore)
        {
            // Play the winning sound for Player 2
            PlayWinningSound();

            // Player 2 wins
            FindObjectOfType<GameController>().GameOver("Player 2 Wins!");
        }
    }

    // Play the win sound when a player wins
    private void PlayWinningSound()
    {
        // Play the win sound
        if (audioSource != null && winSound != null)
        {
            audioSource.PlayOneShot(winSound);  // Play the win sound
        }
    }
}