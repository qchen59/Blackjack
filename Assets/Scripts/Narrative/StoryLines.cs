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
    public bool playerWin;
    public bool dealWin;

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
        left.onClick.AddListener(leftClicked);
        right.onClick.AddListener(rightClicked);

        if (round == 1)
        {
            getStoryLine();

            if (storyLine == 1)
            {
                temp = "The man says to you \" Is all the money there " + green1Who[cardValue] + "\"?";
                mainText.text = temp;
                enableLeftRight("Yes", "Im not sure");

            }
            else if (storyLine == 2)
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

    public void rightClicked()
    {
        if (round == 1)
        {
            if (storyLine == 1)
            {
                if (playerWin)
                {
                    mainText.text = "You're a middle school math teacher, you can't count?\n\"Act normal, that guy over there is really a cop\"\n\"Well I trust the source who gave you the money so it should all be there\" ";
                }
                else
                {
                    mainText.text = "You're ********, you can't count?\n\"Act normal, that guy over there is really a cop\"\n\"Well I trust the source who gave you the money so it should all be there\" ";

                }
            }
            else if (storyLine == 2)
            {
                if (playerWin)
                {
                    mainText.text = "\"Oh no it was the worst outcome wasn't it\"\n\"Do I look familiar to you, Amy?\"\n\"Being a software engineer was your entire world Ron, and you gave it all up\"";
                }
                else
                {
                    mainText.text = "\"Oh no it was the worst outcome wasn't it\"\n\"Do I look familiar to you, ********?\"\n\"Being a software engineer was your entire world Ron, and you gave it all up\"";

                }
            }
            else if (storyLine == 3)
            {
                if (playerWin)
                {
                    mainText.text = "\"As I stated before, I cannot answer that question " + green3Who[cardValue] + "\"\n\"I say this for the safety of your wife and children\"\nMy wife and children?\n\"Yes, don't worry we have them already and they are safe\"";
                }
                else
                {
                    mainText.text = "\"As I stated before, I cannot answer that question " + green3Who[cardValue] + "\"\n\"I say this for the safety of your ********\"\nMy ********?\n\"Yes, don't worry we have them already and they are safe\"";

                }
            }

        }
        left.gameObject.SetActive(false); 
        right.gameObject.SetActive(false);
        keep.gameObject.SetActive(true);
    }



    public void leftClicked()
    {
        if(round == 1)
        {
            if(storyLine == 1)
            {
                if (playerWin)
                {
                    mainText.text = "Great, I can't believe you're paying this much for this. \nAct cool, remember there's, cops, all around these places. \nI've been told you're just a middle school teacher from a small town in Texas, how did you get this kind of money ? ";
                }
                else
                {
                    mainText.text = "Great, I can't believe you're paying this much for this. \nAct cool, remember there's, cops, all around these places. \nI've been told you're just a ******* from a small town in Texas, how did you get this kind of money ? ";

                }
            }else if(storyLine == 2)
            {
                if (playerWin)
                {
                    mainText.text = "\"You don't have to lie to protect me\"\n\"But why would you do such a stupid thing when you have a family\" Your kids were worried sick.\n\"Being a software engineer was your entire world Amy, and you gave it all up\"";
                }
                else
                {
                    mainText.text = "******** \"But why would you do such a stupid thing when you have a family\" Your kids were worried sick.\n\"Being a software engineer was your entire world Amy, and you gave it all up\"";

                }
            }
            else if(storyLine == 3)
            {
                if (playerWin)
                {
                    mainText.text = "\"Great " + green3Who[cardValue] + ", in 10 minutes get up from this table and head outside to the back alley\"\n\"In the meantime, we can play a few more rounds of BlackJack until the van is ready with your family\"";
                }
                else
                {
                    mainText.text = "\"Great " + green3Who[cardValue] + ", in 10 minutes get up from this table and head outside to the ********\"\n\"In the meantime, we can play a few more rounds of BlackJack until the van is ready with your family\"";

                }
            }

        }
        /*        mainCamera.gameObject.SetActive(false);
                NarrativeCam.gameObject.SetActive(true);*/
        left.gameObject.SetActive(false);
        right.gameObject.SetActive(false);
        keep.gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
