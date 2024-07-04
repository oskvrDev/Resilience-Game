using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RamAndWires : MonoBehaviour
{
    [SerializeField]
    private int numberOfSpaces; //number of spaces to move forwards or backwards

    [SerializeField]
    bool isMysteryBox;

    [SerializeField]
    int randomNumberMin;
    [SerializeField]
    int randomNumberMax;

    [SerializeField]
    Text mysteryText;

    private void Start()
    {
        if(mysteryText != null)
        {
            mysteryText.gameObject.SetActive(false);
        }
    }

    public int MoveSpaces()
    {
        if(isMysteryBox) //if mystery box then return random number
        {
            int randomNumber = Random.Range(randomNumberMin, randomNumberMax);
            if(randomNumber == 0)
            {
                randomNumber = 1;
            }
            StartCoroutine(ShowMysteryText(randomNumber));
            return randomNumber;
        }
        else
        {
            return numberOfSpaces; //if ram or wire return number of spaces to player script
        }
    }

    IEnumerator ShowMysteryText(int number)
    {
        //enable text object to show player how many spaces to move
        mysteryText.gameObject.SetActive(true);
        mysteryText.text = "Move " + number.ToString() + " spaces";

        yield return new WaitForSeconds(2f);

        mysteryText.gameObject.SetActive(false);
    }
}