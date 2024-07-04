using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    GameManager gameManager;

    [SerializeField]
    //this will get the player turn script
    PlayerTurnScript playerTurn = null;

    [SerializeField]
    //this will get the board script
    Board board = null;
    //this will save its current position
    int currentPos;

    [SerializeField]
    //this will get the number of houses to move its going to change its value by asking the dice script
    int movepositions;

    [HideInInspector]
    //if its true move, if its not dont
    public bool isMoving = false;

    [HideInInspector]
    public bool hasWon = false;

    //this will check if the player has started moving the dice
    bool hasNewDiceNumber=false;

    //this will check if the enemy already finished the dice
    bool finishedDice=false;

    //this will get the dice object to access the dice script
    public Dice dice;

    [SerializeField]
    Vector2 sizeOfOverLapBox;

    [SerializeField]
    LayerMask RamAndWireLayerMask;

    bool isMovingToRamAndWire=false;

    // Start is called before the first frame update
    void Start()
    {
        hasWon = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        //if is moving is true move
        if (isMoving==true)
        {
            Move();
        }
        else if(isMovingToRamAndWire==true)
        {
            MoveToRamAndWire();
        }

    }

    //this function will work with the dice to make the player move
    public void MoveToRamAndWire()
    {
        //move the player from the current position to the board position
        transform.position = Vector2.MoveTowards(this.transform.position, board.positions[currentPos].position, 5 * Time.deltaTime);

        //if the player reached his destination stop moving, and change player
        if (this.transform.position == board.positions[currentPos].position)
        {
            if (currentPos == board.positions.Length - 1)
            {
                gameManager.CheckWin(this);
                hasWon = true;
            }
      
            //stop moving
            isMoving = false;
            isMovingToRamAndWire = false;
            //tell player turn script that you can play
            playerTurn.canIPlay = true;
            hasNewDiceNumber = false;
            finishedDice = false;
        }
    }

    //this function will work with the dice to make the player move
    public void Move()
    {
        //if this is the first time runing this code in this turn, i do this because this code can only run once or it would call the dice 1000000 times
        if(hasNewDiceNumber==false)
        {
            dice.CallRollDice();
            
        }
        //tell the code to not run the code above
        hasNewDiceNumber = true;
        //then it will check if the dice has already been rolled, and already finished the rolling animation
        if (dice.finishedMovingDice==true && finishedDice==false)
        {
            //if it did finish get the dice number
            movepositions = dice.currentDiceNumber;
            
            //tell the code that it has a new dice number
            hasNewDiceNumber = true;
            //this will increase its current position
            currentPos = currentPos + movepositions;
            movepositions = 0;
            //then tell the code to not run this code again, or it would increase the currentpos 100000 times
            finishedDice = true;
        }

        //if the dice has been roolde, the animation has finished, run the code to make him move
        if (hasNewDiceNumber == true && dice.finishedMovingDice == true && finishedDice == true)
        {
            if (board.positions.Length - 1 < currentPos)
            {
                Debug.Log("AASDASD");
                currentPos = board.positions.Length-1;
            }

            //move the player from the current position to the board position
            transform.position = Vector2.MoveTowards(this.transform.position, board.positions[currentPos].position, 5 * Time.deltaTime);

            //if the player reached his destination stop moving, and change player
            if (this.transform.position == board.positions[currentPos].position)
            {
                if (currentPos == board.positions.Length - 1)
                {
                    gameManager.CheckWin(this);
                    hasWon = true;
                }
                Collider2D a = Physics2D.OverlapBox(this.transform.position, sizeOfOverLapBox, 0, RamAndWireLayerMask);
                if (a != null)
                {
                    StartCoroutine(WaitThenMoveToRam(a));

                    //stop moving
                    isMoving = false;
                   
                   
                } 
                else
                {

                    //stop moving
                    isMoving = false;
                    //tell player turn script that you can play
                    playerTurn.canIPlay = true;
                    hasNewDiceNumber = false;
                    finishedDice = false;
                }
                
            }
        }
       
       
    }

    private IEnumerator WaitThenMoveToRam(Collider2D a_)
    {
        
        yield return new WaitForSeconds(2);

        isMovingToRamAndWire = true;
        movepositions = a_.GetComponent<RamAndWires>().MoveSpaces();
        currentPos += movepositions;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(this.transform.position, new Vector3(sizeOfOverLapBox.x, sizeOfOverLapBox.y, sizeOfOverLapBox.x));
    }
}

