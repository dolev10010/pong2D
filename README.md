# Pong 2D Game

A simple 2D Pong game built with Unity, allowing two players to compete by moving paddles and bouncing the ball to score points. The game features player scores, reset functionality, sound effects, and win conditions.

## Features

- **Two-player mode**: Player 1 and Player 2 can control their respective paddles.
- **Dynamic ball movement**: The ball changes speed, direction, and resets when a player scores.
- **Score tracking**: Each player’s score is tracked and displayed on the screen.
- **Sound effects**: The game includes sound effects for scoring and winning.
- **Win condition**: The game ends when one player reaches a maximum score, and a win message is displayed.
- **UI elements**: The game includes a start button, play again button, and a win message.

## Controls

- **Player 1**: Use the `W` (up) and `S` (down) keys to move the left paddle.
- **Player 2**: Use the `Up Arrow` (up) and `Down Arrow` (down) keys to move the right paddle.

## How to Play

1. Click the **Start** button to begin the game.
2. Player 1 and Player 2 can move their paddles to prevent the ball from entering their goal.
3. Each time a player scores, the ball resets to the center, accompanied by a scoring sound effect.
4. The first player to reach the maximum score (default: 5) wins, and a winning sound effect is played along with the win message.
5. To play again, click the **Play Again** button after the game ends.

## How to Run

1. Clone the repository:
   ```bash
   git clone https://github.com/dolev10010/pong2D.git
   cd pong2D

2. Open the project in Unity.
3. Press the Play button in Unity to start the game.

## Sounds

The game uses sound effects to enhance the gameplay experience:

- Scoring Sound: Played whenever a player scores a point.
- Winning Sound: Played when a player wins the game.
- The sounds are managed using the AudioSource component attached to the GameManager   object. Here’s how the sounds are handled in the script:

## Key Scripts Overview

### 1. BallController.cs
Controls the ball's movement, speed, and interaction with the goals. It resets the ball when a player scores and ensures the ball's speed remains within defined limits.

### 2. PaddleController.cs
Handles paddle movement for both players. The paddles move vertically, and their movement is clamped within the game boundaries.

### 3. GameManager.cs
Manages the game logic, including score tracking, resetting the game, determining the winner, and playing sound effects.

### 4. GameController.cs
Handles the game UI, such as starting the game, displaying the win message, and resetting the game.
