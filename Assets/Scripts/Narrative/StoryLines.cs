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

    public int storyLine = 0;
    public int cardValue = 0;
    string[] green1Who = new string[]{"Joshua", "Karen", "Matthew", "John"};
    string[] green1How1= new string[] { "FATHER", "BROTHER", "AUNT", "MOTHER" };
    string[] green1How2 = new string[] { "Yo, snap out of it!", "Pay Attention!", "Hey!", "Wake up!" };

    string[] green2Who = new string[] { "scared", "concerned", "apprehensive", "happy" };
    string[] green2How1 = new string[] { "Cancun", "Egypt", "Florida", "Bahamas" };
    string[] green2How2 = new string[] { "Spouse", "Secret Lover", "Husband", "Ex-Husband" };

    string[] green3Who = new string[] { "Jack", "Mya", "Sam", "Paul" };
    string[] green3How1 = new string[] { "What are you talking about", "What do you have amnesia or something", "What are you saying", "Are you serious" };
    string[] green3How2 = new string[] { "She hasn't leg go from the hug", "She won't let go of you", "The grip from her hug gets tighter", "Her embrace tightens" };

    public int getStoryLine()
    {
        System.Random rand = new System.Random();
        storyLine = rand.Next(1, 3);
        return storyLine;
    }
    // Start is called before the first frame update
    void Start()
    {
        if(round == 1)
        {

            if (getStoryLine() == 1)
            {
                mainText.text = "The man says to you \" Is all the money there " + green1Who[cardValue] + "\"?";
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
