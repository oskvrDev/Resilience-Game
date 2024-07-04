using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnScript : MonoBehaviour
{
    [SerializeField]
    Player[] players; //store players

    [SerializeField]
    bool isAi = false; //If its an Ai

    [HideInInspector]
    public int currentPlayer; //store current player number
    int numberOfPlayers; //store number of players in scene

    public GameManager gameManager;

    [HideInInspector]
    public bool canIPlay = true;
    private void Start()
    {
        if(isAi==false)
        {
            currentPlayer = -1; //set to first player
        }
        numberOfPlayers = players.Length; //set number of players

    }

    void Update()
    {
        
        if (Input.GetKeyDown("space") && canIPlay == true && isAi == false)//if the player presses space call change player
        {
            ChangePlayer();
        }
        else if (canIPlay == true && isAi == true && currentPlayer == 1 && Input.GetKeyDown("space"))
        {
            
            ChangePlayer();
            Debug.Log("ASADUSAJDSAUDJSADUSADJSADJSAWQ");
        }
        else if (canIPlay == true && isAi == true && currentPlayer == 0)
        {
            
            Debug.Log("lllllllllllllllllllll");
            ChangePlayer();
        }
        else if(canIPlay == true && isAi == true && players[0].hasWon && players[1].hasWon)
        {
            ChangePlayer();
        }
    }

    public void ChangePlayer()
    {

        if (currentPlayer == numberOfPlayers - 1)
        {
            currentPlayer = 0; //if at last player change to first player

        }
        else
        {
            currentPlayer++; //change player to next player

        }

        if (players[currentPlayer].hasWon)
        {
            bool everyoneHasWon = true;
            foreach (Player i in players)
            {
                if (!i.hasWon)
                {
                    everyoneHasWon = false;
                }
            }
            if (everyoneHasWon == false)
            {
                if(!isAi)
                {
                    ChangePlayer();
                }
            }
            else
            {
                //WRITTEN BY KATHERINE BELOW(just this else)
                gameManager.GetComponent<GameManager>().GameFinished();
            }

        }
        canIPlay = false;
        players[currentPlayer].isMoving = true;//tell the player to move

    }

}