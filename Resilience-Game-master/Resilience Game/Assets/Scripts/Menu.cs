using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    //WRITTEN BY KATHERINE BELOW

    public void Player1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public void Player2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

    }
    public void Player3()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);

    }
    public void Player4()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }
}
