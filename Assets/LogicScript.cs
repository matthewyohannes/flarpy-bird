using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LogicScript : MonoBehaviour
{

    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public bool isGameOver = false;

    public AudioSource bellSFX;


    [ContextMenu("Increase Score")] // allows function to be ran in unity itself
    public void addScore(int scoreToAdd) {
        if (!isGameOver) { // makes sure game is not over so that score can update
            playerScore += scoreToAdd;
            scoreText.text = playerScore.ToString();
            bellSFX.Play();
        }
    }

    public void restartGame() { // gets ran when game is over and user presses play again
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // since we are just working with one scene this will load the scene from beginning
    }

    public void gameOver() { // this should be called when the bird crashes into pipe
        gameOverScreen.SetActive(true); // this displays game over screen
        isGameOver = true; // flag to let score adder know that the game is over
    }

}
