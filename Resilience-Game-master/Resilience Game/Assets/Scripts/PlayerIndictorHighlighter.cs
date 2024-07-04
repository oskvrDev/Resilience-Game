using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerIndictorHighlighter : MonoBehaviour
{
    //WRITTEN BY KATHERINE BELOW

    [SerializeField]
    GameManager gameManager;
    [SerializeField]
    PlayerTurnScript playerTurnScript;

    public Image playerOnePicture=null;
    public Image playerTwoPicture=null;
    public Image playerThreePicture=null;
    public Image playerFourPicture=null;


    public void HightlightPlayer()
    {
        if(playerTurnScript.currentPlayer == 0)
        {
            playerOnePicture.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        else if (playerOnePicture != null)
        {
            playerOnePicture.GetComponent<Image>().color = new Color32(65, 65, 65, 100);
        }
        if (playerTurnScript.currentPlayer == 1)
        {
            playerTwoPicture.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        else if (playerTwoPicture != null)
        {
            playerTwoPicture.GetComponent<Image>().color = new Color32(65, 65, 65, 100);
        }
        if (playerTurnScript.currentPlayer == 2)
        {
            playerThreePicture.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        else if (playerThreePicture != null)
        {
            playerThreePicture.GetComponent<Image>().color = new Color32(65, 65, 65, 100);
        }
        if (playerTurnScript.currentPlayer == 3)
        {
            playerFourPicture.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        else if(playerFourPicture != null)
        {
            playerFourPicture.GetComponent<Image>().color = new Color32(65, 65, 65, 100);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if(playerOnePicture != null)
        {
            playerOnePicture.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }

        if (playerTwoPicture != null)
        {
            playerTwoPicture.GetComponent<Image>().color = new Color32(65, 65, 65, 100);
        }
            
        if(playerThreePicture != null)
        {
            playerThreePicture.GetComponent<Image>().color = new Color32(65, 65, 65, 100);
        }
        
        if(playerFourPicture != null)
        {
            playerFourPicture.GetComponent<Image>().color = new Color32(65, 65, 65, 100);
        }
    }

    // Update is called once per frame
    void Update()
    {
        HightlightPlayer();
    }
}
