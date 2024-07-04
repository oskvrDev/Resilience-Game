using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
   [SerializeField]
    private Sprite[] diceSides;
    private SpriteRenderer render;
    private AudioSource diceSound;

    public int currentDiceNumber;
    public bool finishedMovingDice = true;

    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("DiceSprites/");
        render.sprite = diceSides[5];
        diceSound = GetComponent<AudioSource>(); 
    }

    public void CallRollDice()
    {
        StartCoroutine(RollDice());
    }

    private IEnumerator RollDice()
    {
       // diceSound.Play();
        finishedMovingDice = false;
        int diceValue = 0;

        for (int i = 0; i <=15; i++)
        {
            diceValue = Random.Range(1, 7);
            render.sprite = diceSides[diceValue - 1];
            yield return new WaitForSeconds(0.075f);
        }
        finishedMovingDice = true;
        currentDiceNumber = diceValue;
        yield return diceValue;
    }
}
