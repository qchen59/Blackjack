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
    public bool playerWin = false;
    public bool dealWin = false;

    public string temp = "";

    public int storyLine = 0;
    public int cardValue = 0;
    string[] green1Who = new string[] { "Joshua", "Karen", "Matthew", "John", "Robert", "Michael", "Morgan", "Jaime", "Kendall", "Skyler", "Frankie", "Charles", "Patrick" };
    string[] green1How1 = new string[] { "Father", "Mother", "Brother", "Husband", "Daughter", "Sister", "Grandfather", "Grandmother", "Father-in-law", "Mother-in-law", "Son", "Bestfriend", "Sister-in-law" };
    string[] green1How2 = new string[] { "Yo, snap out of it!", "Pay Attention!", "Hey!", "Wake up!", "Yo", "Are you listening", "Listen to me", "Lookup", "Hello", "Listen up", "All right", "Now then", "Here" };

    string[] green2Who = new string[] { "scared", "concerned", "apprehensive", "happy", "Worried", "Upset", "Uneasy", "Distressed", "Anxious", "Troubled", "Caring", "Unsettled", "Bothered" };
    string[] green2How1 = new string[] { "Cancun", "Egypt", "Florida", "Bahamas", "Mexico", "Italy", "Greece", "Costa Rica", "Bora Bora", "Maldives", "Fiji", "France", "Tahiti" };
    string[] green2How2 = new string[] { "Spouse", "Secret Lover", "Husband", "Ex-Husband", "Partner", "Mate", "Other half", "Better half", "Hubby", "Man", "Love", "Lover", "Consort" };

    string[] green3Who = new string[] { "Jack", "Mya", "Sam", "Paul", "Robert", "Cynthia", "Watson", "Gary", "Lance", "Bruno", "Bill", "Roxanne", "Lucil" };
    string[] green3How1 = new string[] { "What are you talking about", "What do you have amnesia or something", "What are you saying", "Are you serious", "Are you crazy", "You don't remember", "How do you not know?", "Did you bump your head?", "You can't be serious", "Did you fall on your way in here?", "Did you forget", "No way", "You're crazy" };
    string[] green3How2 = new string[] { "She hasn't leg go from the hug", "She won't let go of you", "The grip from her hug gets tighter", "Her embrace tightens", "Her grip fills tighter", "Her embrace almost feels like restraint.", "She locks her hands.", "The hug turns into a feeling of restraint.", "It feels like I'm being hugged by a bodybuilder", "Her tight hug feels like she's been working out", "Her tight hug starts to get painful", "Her tight hug starts to get painful", "Her hug feels like she trying to hold me down in place" };

    public void setPlayWin()
    {
        this.playerWin = true;
    }
    public int getStoryLine()
    {
        System.Random rand = new System.Random();
        storyLine = rand.Next(1, 4);
        return storyLine;
    }
    // Start is called before the first frame update
    public void start()
    {
        print("the round in narrative is" + round);
        print("card Value is " + cardValue);
        print("the story line is " + storyLine);
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
        else if (round == 2)
        {
            if (storyLine == 1)
            {
                temp = "\"Why are you acting so weird? Do you remember why we're here?\"";
                mainText.text = temp;
                enableLeftRight("Yes", "No");

            }
            else if (storyLine == 2)
            {
                if (playerWin)
                {
                    mainText.text = "\"None of this would've happened if it wasn't for me\"\n\"Do you remember the night in the " + green1How1[cardValue] + " or your kid's names\"\n\"Well I hope what they gave you was enough\"\nLooking into the eyes of this man you can they are sick.\nYou can remember a helmet being placed on you by men in white lab coats.\n\"This will hurt only for a moment Amy\"";

                }
                else
                {
                    mainText.text = "\"None of this would've happened if it wasn't for me\"\n\"Do you remember the night in the " + green1How1[cardValue] + " or your kid's names\"\n\"Well I hope what they gave you was enough\"\n********\nYou can remember a helmet being placed on you by men in white lab coats.\n\"This will hurt only for a moment Amy\"";

                }
                enableKeep();

            }
            else
            {
                mainText.text = "What do you mean by my family?\n\"" + green3How1[cardValue] + ", all this was your idea, im just the man with the needed connections\"";
                enableLeftRight("Connections?", "\"Whats going on ? \"");

            }
        }
        else if (round == 3)
        {
            if (storyLine == 1)
            {
                temp = "It seems like the more you play the faster your memories come to you\nYou look around and see a man looking at you.\n\"" + green1How2[cardValue] + "\" Says the man who is sitting across from you.\n\"You ready? I'm going to bring it out, slide the briefcase over to me\"\nYou slide the briefcase over to you, as you bend down to push it over you feel something on your chest.\nYou start to grab at it but the odd man staring at shakes his head, no.\n";
                mainText.text = temp;
                enableLeftRight("Ignore", "Trust Him");

            }
            else if (storyLine == 2)
            {
                if (playerWin)
                {
                    mainText.text = "As you finish up the final round, the man's wedding band slips off his finger.\nAs you grab it for him and hand it over you notice a wedding ring on your ring finger as well.\n\"Did that help you remember?\"";

                }
                else
                {
                    mainText.text = "As you finish up the final round, the man's ******** slips off his finger.\nAs you grab it for him and hand it over you notice a ******** as well.\n\"Did that help you remember?\"";

                }
                enableKeep();

            }
            else
            {
                if (playerWin)
                {
                    mainText.text = "The man looks at his phone.\n\"Looks like the preparations are ready to leave the money and go to the back alley\"\n\"With your bad memory, it looks like getting used to your new identities will be a breeze\"\nYou walk to the back alley, where a van opens up, your wife immediately hugs and while your kids are crying and looked confused.\nYou remember that you're a ring leader of one of the world's largest drug businesses. The feds have caught wind of you and you and your family are headed off with new identities and a new life in another country.\nYou look at your wife and say,";

                }
                else
                {
                    mainText.text = "The man looks at his phone.\n\"Looks like the preparations are ready to leave the money and go to the back alley\"\n\"With your bad memory, it looks like getting used to your new identities will be a breeze\"\nYou walk to the ********, where a van opens up, your wife immediately hugs and while your kids are crying and looked confused.\nYou remember that you're a ********,  of one of the world's largest drug businesses. The feds have caught wind of you and you and your family are headed off with new identities and a new life in another country.\nYou look at your wife and say,";

                }
                enableLeftRight("How are you?", "Im sorry");

            }
        }

    }


    public void enableKeep()
    {
        keep.gameObject.SetActive(true);
    }
    public void enableLeftRight(string leftS, string rightS)
    {

            left.gameObject.SetActive(true);
            right.gameObject.SetActive(true);
            left.GetComponentInChildren<Text>().text = leftS;
            right.GetComponentInChildren<Text>().text = rightS;


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
        else if(round == 2)
        {

            if (storyLine == 1)
            {
                if (playerWin)
                {
                    mainText.text = "\"I can't say too much but remember ******** you wanted?\"\n\nYour memories are slowly coming back.\nYou remember a traumatic phone call from your " + green1How1[cardValue] + ".\n\"********!\" Your mother cries out.\nYou remember calling your best friend who is a detective, you remember him saying \"I found her\"";
                }
                else
                {
                    mainText.text = "\"I can't say too much but remember ******** you wanted?\"\n\nYour memories are slowly coming back.\nYou remember a traumatic phone call from your " + green1How1[cardValue] + ".\n\"********!\" Your mother cries out.\nYou remember calling your best friend who is a detective, you remember him saying \"I found her\"";

                }
            }
            else if (storyLine == 2)
            {
            }
            else if (storyLine == 3)
            {
                if (playerWin)
                {
                    mainText.text = "\"Look you said you were in big trouble and your family needed help\"\n\"I'm providing that for you, just trust me and stop asking questions\"\n\"You told me where to pick up your family and you would come back with the money\"\n\"Now keep your voice down and let's play another round\"";
                }
                else
                {
                    mainText.text = "\"Look you said you were in big trouble and your family needed help\"\n\"I'm providing that for you, just trust me and stop asking questions\"\n\"You told me where to ******** family and you would come back with the money\"\n\"Now keep your voice down and let's play another round\"";

                }
            }

        }
        else
        {

            if (storyLine == 1)
            {
                if (playerWin)
                {
                    mainText.text = "\"Something about this man seems like I should trust him\"\nYou look up as a woman walks up to you in tears and hugs you.\n\nThe memories come flooding back.\nYour sister was kidnapped by a sex trafficking ring.\nYour best friend helped you discover her location in captivity.\nHe helped make a deal with the ring leader to pay for her back.\nOnce she came out they would arrest the man and save your sister.\n";
                }
                else
                {
                    mainText.text = "\"Something about this man seems like I should ******** him\"\nYou look up as a woman walks up to you in tears and hugs you.\n\nThe memories come flooding back.\nYour sister was ******** by a sex trafficking ring.\nYour best friend helped you discover her location in captivity.\nHe helped make a deal with the ring leader to pay for her back.\nOnce she came out they would arrest the man and save your sister.\n";

                }
            }
            else if (storyLine == 2)
            {
                mainText.text = "\"Even after the procedure, you're still a terrible liar\"\n\"I'm sorry, I know the doctors said I shouldn't tell you everything at once because it can be traumatizing but I can't help it\"\n\"I'm your " + green2How2[cardValue] + ", Amy\"\nI have an illness.\nYou decided to run a very dangerous trial experiment since it offered enough money to help me get the surgery I needed.\nBut...\nAt the cost of your memories\n";
            }
            else if (storyLine == 3)
            {
     
            mainText.text = green3How2[cardValue] + "\nWith tears in her eyes, she mouths the words, \n\"No, I'm sorry\"\n\"FREEZE!!\"\n\"Put your hands where I can see them!\"";

                
            }
            keep.GetComponentInChildren<Text>().text = "Retry";
        }
        left.gameObject.SetActive(false);
        right.gameObject.SetActive(false);
        keep.gameObject.SetActive(true);
    }



    public void leftClicked()
    {
        if (round == 1)
        {
            if (storyLine == 1)
            {
                if (playerWin)
                {
                    mainText.text = "Great, I can't believe you're paying this much for this. \nAct cool, remember there's, cops, all around these places. \nI've been told you're just a middle school teacher from a small town in Texas, how did you get this kind of money ? ";
                }
                else
                {
                    mainText.text = "Great, I can't believe you're paying this much for this. \nAct cool, remember there's, cops, all around these places. \nI've been told you're just a ******* from a small town in Texas, how did you get this kind of money ? ";

                }
            }
            else if (storyLine == 2)
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
            else if (storyLine == 3)
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

        }else if(round == 2)
        {
            if (storyLine == 1)
            {
                if (playerWin)
                {
                    mainText.text = "\"I can tell you're lying\"\n\"Look, you came here to buy something that's technically not legal\"\n\"You came to me for this, so you need to act like it\"\n\nYour memories are slowly coming back.\nYou remember a traumatic phone call from your "+ green1How1[cardValue] + ".\n\"Rachel is missing!\" Your mother cries out.\nYou remember calling your best friend who is a detective, you remember him saying \"I found her\"";
                }
                else
                {
                    mainText.text = "\"I can tell you're lying\"\n\"Look, you came here to buy something that's ********\"\n\"You came to me for this, so you need to act like it\"\n\nYour memories are slowly coming back.\nYou remember a traumatic phone call from your " + green1How1[cardValue] + ".\n\"********!\" Your mother cries out.\nYou remember calling your best friend who is a detective, you remember him saying \"I found her\"";

                }
            }
            else if (storyLine == 2)
            {

            }
            else if (storyLine == 3)
            {
                if (playerWin)
                {
                    mainText.text = "\"Look you said you were in big trouble and your family needed help\"\n\"I'm providing that for you, just trust me and stop asking questions\"\n\"You told me where to pick up your family and you would come back with the money\"\n\"Now keep your voice down and let's play another round\"";
                }
                else
                {
                    mainText.text = "\"Look you said you were in big trouble and your family needed help\"\n\"I'm providing that for you, just trust me and stop asking questions\"\n\"You told me where to ******** family and you would come back with the money\"\n\"Now keep your voice down and let's play another round\"";

                }
            }

        }
        else
        {
            if (storyLine == 1)
            {
                if (playerWin)
                {
                    mainText.text = "\"You alright man, don't worry its almost here\"\nAs you grab this thing under your shirt you look up to see a young woman staring back at you.\nShe looks familiar but...\n\"Freeze!\"\n\nThe memories come flooding back.\nYour sister was kidnapped by a sex trafficking ring.\nYour best friend helped you discover her location in captivity.\nHe helped make a deal with the ring leader to pay for her back.\nOnce she came out they would arrest the man and save your sister.\n";
                }
                else
                {
                    mainText.text = "\"You alright man, don't worry its almost here\"\nAs you grab this thing under your shirt you look up to see a young woman staring back at you.\nShe looks familiar but...\n\"Freeze!\"\n\nThe memories come flooding back.\nYour sister was ******* by a sex trafficking ring.\nYour best friend helped you discover her location in captivity.\nHe helped make a deal with the ring leader to pay for her back.\nOnce she came out they would arrest the man and save your sister.\n";
                }
            }
            else if (storyLine == 2)
            {
                mainText.text = "\"I'm sorry, I know the doctors said I shouldn't tell you everything at once because it can be traumatizing but I can't help it\"\n\"I'm your " + green2How2[cardValue] + ", Amy\"\nI have an illness.\nYou decided to run a very dangerous trial experiment since it offered enough money to help me get the surgery I needed.\nBut...\nAt the cost of your memories\n";
            }
            else if (storyLine == 3)
            {

                mainText.text = green3How2[cardValue] + "\nShe says something but it's muffled from her face buried into your shirt.\nBut as you look and notice the police surrounding you, you realize she said,\n\"I'm sorry\"";


            }
            keep.GetComponentInChildren<Text>().text = "Retry";

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


