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

    public string storyScript;

    public Text scriptText;

    bool selected = false;

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
        SetStoryScript("This is story script " + value);
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
            scriptText.gameObject.SetActive(true);
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
