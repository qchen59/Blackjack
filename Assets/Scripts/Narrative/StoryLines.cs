using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryLines : MonoBehaviour
{

    public Text mainText;
    public Button left;
    public Button right;
    public Button keep;
    public int round = 0;

    public string temp = "";

    public int storyLine = 0;
    public int cardValue = 0;
    string[] green1Who = new string[]{"Joshua", "Karen", "Matthew", "John", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
    string[] green1How1= new string[] { "FATHER", "BROTHER", "AUNT", "MOTHER", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
    string[] green1How2 = new string[] { "Yo, snap out of it!", "Pay Attention!", "Hey!", "Wake up!", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

    string[] green2Who = new string[] { "scared", "concerned", "apprehensive", "happy", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
    string[] green2How1 = new string[] { "Cancun", "Egypt", "Florida", "Bahamas", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
    string[] green2How2 = new string[] { "Spouse", "Secret Lover", "Husband", "Ex-Husband", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

    string[] green3Who = new string[] { "Jack", "Mya", "Sam", "Paul", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
    string[] green3How1 = new string[] { "What are you talking about", "What do you have amnesia or something", "What are you saying", "Are you serious", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
    string[] green3How2 = new string[] { "She hasn't leg go from the hug", "She won't let go of you", "The grip from her hug gets tighter", "Her embrace tightens", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

    public int getStoryLine()
    {
        System.Random rand = new System.Random();
        storyLine = rand.Next(1, 4);
        return storyLine;
    }
    // Start is called before the first frame update
    void Start()
    {
        print("the round in narrative is" + round);
        print("card Value is " + cardValue);
        if(round == 1)
        {

            if (getStoryLine() == 1)
            {
                temp = "The man says to you \" Is all the money there " + green1Who[cardValue] + "\"?";
                mainText.text = temp;
                enableLeftRight("Yes", "Im not sure");

            }
            else if (getStoryLine() == 2)
            {
                mainText.text = "In a somewhat  " + green2Who[cardValue] + "tone the man says to you \" Is it over? Are you ok\"?";
                enableLeftRight("Yes", "I can't remember anything");

            }
            else
            {
                mainText.text = "You still want to do this?\" The man says";
                enableLeftRight("Yes", "\"Who are you ? \"");

            }

        }
        else if( round == 2)
        {

        }
        else if(round == 3)
        {

        }

    }

    public void enableLeftRight(string leftS, string rightS)
    {


        if (round == 1)
        {
            left.gameObject.SetActive(true);
            right.gameObject.SetActive(true);
            left.GetComponentInChildren<Text>().text = leftS;
            right.GetComponentInChildren<Text>().text = rightS;

        }
        else if (round == 2)
        {

        }
        else if (round == 3)
        {

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
