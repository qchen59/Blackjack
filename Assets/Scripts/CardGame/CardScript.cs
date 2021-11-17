using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

public class CardScript : MonoBehaviour
{
    // Value of card, 2 of clubs = 2, etc
    public int value = 0;

    public int round = 0;
   // public int bigRound = 1;
    public string storyScript;

    public Text scriptText;
    public Text popUp;
    public Text mainText;
    public Button confirm;
    public Button hitBtn;
    public Button standBtn;
    public Button dealBtn;

    bool selected = false;




    // Templete { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
    // Templete round 5 { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "self"};

    private string[] cardRound1 = new string[13] { "You are in a casino.", "2", "You are in an amusement park.", "4", "5", "6", "7", "8", "9", "10", "You are in a movie theatre.", "Q", "K" };
    private string[] cardRound2 = new string[13] { "A", "You are a doctor in your late thirties.", "3", "4", "5", "6", "You are an NCSU student.", "8", "9", "You are a lift operator.", "J", "Q", "K" };
    private string[] cardRound3S1 = new string[14] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "self" };
    private string[] cardRound3S2 = new string[14] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "self" };
    private string[] cardRound3S3 = new string[14] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "self" };
    public string GetStoryScript()
    {


        return storyScript;
    }

    public void SetStoryScript(string newScript)
    {
        storyScript = newScript;
        
    }

    public void RoundAdd()
    {
        round++;
    }

    public int GetRound()
    {
        return round;
    }

    public int GetValueOfCard()
    {
        return value;
    }

    public void SetValue(int newValue)
    {
        value = newValue;

        //     if (round == 0)
        //     {
        //        SetStoryScript(cardRound1[value]);
        //     }
        //     if (round == 1)
        //     {
        //          SetStoryScript(cardRound2[value]);
        //     }
        //     else
        //    {
        //         SetStoryScript("This is story script " + value);
        //        Debug.Log(round);
        //       }


        SetStoryScript("This is story script " + value);
        Debug.Log(round);
       // bigRound++;
    }

    public string GetSpriteName()
    {
        return GetComponent<SpriteRenderer>().sprite.name;
    }

    public void SetSprite(Sprite newSprite)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
    }

    public void ResetCard()
    {
        Sprite back = GameObject.Find("Deck").GetComponent<DeckScript>().GetCardBack();
        gameObject.GetComponent<SpriteRenderer>().sprite = back;
        value = 0;
    }


    public void OnMouseDown()
    {
        if (GameObject.Find("GameManager").GetComponent<GameManager>().playerWin == true)
        {
            hitBtn.gameObject.SetActive(false);
            standBtn.gameObject.SetActive(false);
            dealBtn.gameObject.SetActive(false);
            scriptText.gameObject.SetActive(true);

            mainText.text = "Card " + value + " is selected!";
            confirm.gameObject.SetActive(true);
            scriptText.text = storyScript;
            GameObject.Find("GameManager").GetComponent<GameManager>().playerWin = false;
        }

    }

    public void DisplayStory()
    {
        print(storyScript);
        print(value);
        scriptText.gameObject.SetActive(true);
        scriptText.text = storyScript;
    }


}
