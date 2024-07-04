using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //WRITTEN BY KATHERINE BELOW (the function name was not made by me as it is referenced elsewhere, but everything else here was.)

    public GameObject winningScene;
    public GameObject gameFinished;
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Player4;

    public bool gameHasAWinner;
    public static bool isGameOver;

    private void Start()
    {
        Time.timeScale = 1f;    
    }

    public void CheckWin(Player player)
    {
        if(player.gameObject.name == "Player 1 (Red)" && Player1 != null && gameHasAWinner == false)
        {
            Debug.Log("WINNING CONDITION for red");
            Time.timeScale = 0f;
            gameHasAWinner = true;
            winningScene.SetActive(true);
            Player1.SetActive(true);
        }
        else if (player.gameObject.name == "Player 2 (Yellow)" && Player2 != null && gameHasAWinner == false)
        {
            Debug.Log("WINNING CONDITION for yellow");
            Time.timeScale = 0f;
            gameHasAWinner = true;
            winningScene.SetActive(true);
            Player2.SetActive(true);
        }
        else if (player.gameObject.name == "Player 3 (Green)" && Player3 != null && gameHasAWinner == false)
        {
            Debug.Log("WINNING CONDITION for green");
            Time.timeScale = 0f;
            gameHasAWinner = true;
            winningScene.SetActive(true);
            Player3.SetActive(true);
        }
        else if (player.gameObject.name == "Player 4 (Blue)" && Player4 != null && gameHasAWinner == false)
        {
            Debug.Log("WINNING CONDITION for blue");
            Time.timeScale = 0f;
            gameHasAWinner = true;
            winningScene.SetActive(true);
            Player4.SetActive(true);
        }
    }

    public void GameFinished()
    {
        gameFinished.SetActive(true); 
    }

    public void ExitGame()
    {
        /*Debug.Log("Game Closed");
        Application.Quit();*/
        SceneManager.LoadScene("Menu");
    }

    public void ContinueButton()
    {
        winningScene.SetActive(false);
        Time.timeScale = 1f;
    }
}
