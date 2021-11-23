using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryLines : MonoBehaviour
{

    public Text mainText;
    public Text scriptText;
    public string script = "";
    public Button left;
    public Button right;
    public Button keep;
    public Button next;
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

    public void resetPlayWin()
    {
        this.playerWin = false;
    }

    public int getStoryLine()
    {
        System.Random rand = new System.Random();
        storyLine = rand.Next(1, 4);
        return storyLine;
    }

    void Start()
    {
        left.onClick.AddListener(leftClicked);
        right.onClick.AddListener(rightClicked);
        next.onClick.AddListener(NextScript);
    }

    public void resetText()
    {
        script = "";
        scriptText.text = "";
    }




        // Start is called before the first frame update
        public void newRound()
    {
        print("the round in narrative is" + round);
        print("card Value is " + cardValue);
        print("the story line is " + storyLine);

        if (round == 1)
        {
            getStoryLine();

            if (storyLine == 1)
            {
                temp = "The man says to you \" Is all the money there " + green1Who[cardValue] + "\"?\n\n";
                mainText.text = temp;
                script += temp;
                enableLeftRight("Yes", "Im not sure");

            }
            else if (storyLine == 2)
            {
                temp = "In a somewhat  " + green2Who[cardValue] + "tone the man says to you \" Is it over? Are you ok\"?\n\n";
                mainText.text = temp;
                script += temp;
                enableLeftRight("Yes", "I can't remember anything\n\n");

            }
            else
            {
                temp = "You still want to do this?\" The man says\n\n";
                mainText.text = temp;
                script += temp;
                enableLeftRight("Yes", "\"Who are you ? \"\n\n");

            }

        }
        else if (round == 2)
        {
            if (storyLine == 1)
            {
                temp = "\"Why are you acting so weird? Do you remember why we're here?\"\n\n";
                mainText.text = temp;
                script += temp;
                enableLeftRight("Yes", "No");

            }
            else if (storyLine == 2)
            {
                if (playerWin)
                {
                    temp = "\"None of this would've happened if it wasn't for me\"\n\n\"Do you remember the night in the " + green1How1[cardValue] + " or your kid's names\"\n\n\"Well I hope what they gave you was enough\"\n\nLooking into the eyes of this man you can they are sick.\n\nYou can remember a helmet being placed on you by men in white lab coats.\n\n\"This will hurt only for a moment Amy\"\n\n";
                    mainText.text = temp;
                    script += temp;
                }
                else
                {
                    temp = "\"None of this would've happened if it wasn't for me\"\n\n\"Do you remember the night in the " + green1How1[cardValue] + " or your kid's names\"\n\n\"Well I hope what they gave you was enough\"\n\n********\n\nYou can remember a helmet being placed on you by men in white lab coats.\n\n\"This will hurt only for a moment Amy\"\n\n";
                    mainText.text = temp;
                    script += temp;
                }
                enableKeep();

            }
            else
            {
                temp = "What do you mean by my family?\n\n\"" + green3How1[cardValue] + ", all this was your idea, im just the man with the needed connections\"\n\n";
                mainText.text = temp;
                script += temp;
                enableLeftRight("Connections?", "\"Whats going on ? \"");

            }
        }
        else if (round == 3)
        {
            if (storyLine == 1)
            {
                temp = "It seems like the more you play the faster your memories come to you\n\nYou look around and see a man looking at you.\n\n\"" + green1How2[cardValue] + "\" Says the man who is sitting across from you.\n\n\"You ready? I'm going to bring it out, slide the briefcase over to me\"\n\nYou slide the briefcase over to you, as you bend down to push it over you feel something on your chest.\n\nYou start to grab at it but the odd man staring at shakes his head, no.\n\n";
                mainText.text = temp;
                script += temp;
                enableLeftRight("Ignore", "Trust Him");

            }
            else if (storyLine == 2)
            {
                if (playerWin)
                {
                    temp = "As you finish up the final round, the man's wedding band slips off his finger.\n\nAs you grab it for him and hand it over you notice a wedding ring on your ring finger as well.\n\n\"Did that help you remember?\"\n\n";
                    mainText.text = temp;
                    script += temp;
                }
                else
                {
                    temp = "As you finish up the final round, the man's ******** slips off his finger.\n\nAs you grab it for him and hand it over you notice a ******** as well.\n\n\"Did that help you remember?\"\n\n";
                    mainText.text = temp;
                    script += temp;
                }
                enableLeftRight("No", "Yes");

            }
            else
            {
                if (playerWin)
                {
                    temp = "The man looks at his phone.\n\n\"Looks like the preparations are ready to leave the money and go to the back alley\"\n\n\"With your bad memory, it looks like getting used to your new identities will be a breeze\"\n\nYou walk to the back alley, where a van opens up, your wife immediately hugs and while your kids are crying and looked confused.\n\nYou remember that you're a ring leader of one of the world's largest drug businesses. The feds have caught wind of you and you and your family are headed off with new identities and a new life in another country.\n\nYou look at your wife and say,\n\n";
                    mainText.text = temp;
                    script += temp;
                }
                else
                {
                    temp = "The man looks at his phone.\n\n\"Looks like the preparations are ready to leave the money and go to the back alley\"\n\n\"With your bad memory, it looks like getting used to your new identities will be a breeze\"\n\nYou walk to the ********, where a van opens up, your wife immediately hugs and while your kids are crying and looked confused.\n\nYou remember that you're a ********,  of one of the world's largest drug businesses. The feds have caught wind of you and you and your family are headed off with new identities and a new life in another country.\n\nYou look at your wife and say,\n\n";
                    mainText.text = temp;
                    script += temp;
                }
                enableLeftRight("How are you?", "Im sorry");

            }
            scriptText.text = script;
        }

    }
    public void enableNext()
    {
        left.gameObject.SetActive(false);
        right.gameObject.SetActive(false);
        next.gameObject.SetActive(true);
    }
    
    public void NextScript()
    {
        if (round == 1)
        {

        } else if (round == 2)
        {
            if (storyLine == 1)
            {
                if (playerWin)
                {
                    temp = "Your memories are slowly coming back.\n\nYou remember a traumatic phone call from your " + green1How1[cardValue] + ".\n\n\"Rachel is missing!\" Your mother cries out.\n\nYou remember calling your best friend who is a detective, you remember him saying \"I found her\"\n\n";
                    mainText.text = temp;
                    script += temp;
                    scriptText.text = script;
                } else
                {
                    temp = "Your memories are slowly coming back.\n\nYou remember a traumatic phone call from your " + green1How1[cardValue] + ".\n\n\"********!\" Your mother cries out.\n\nYou remember calling your best friend who is a detective, you remember him saying \"I found her\"\n\n";
                    mainText.text = temp;
                    script += temp;
                    scriptText.text = script;
                }
            }
        } else
        {
            if (storyLine == 1)
            {
                if (playerWin)
                {
                    temp = "\n\nThe memories come flooding back.\n\nYour sister was kidnapped by a sex trafficking ring.\n\nYour best friend helped you discover her location in captivity.\n\nHe helped make a deal with the ring leader to pay for her back.\n\nOnce she came out they would arrest the man and save your sister.\n\n";
                    mainText.text = temp;
                    script += temp;
                    scriptText.text = script;
                }
                else
                {
                    temp = "\n\nThe memories come flooding back.\n\nYour sister was ******** by a sex trafficking ring.\n\nYour best friend helped you discover her location in captivity.\n\nHe helped make a deal with the ring leader to pay for her back.\n\nOnce she came out they would arrest the man and save your sister.\n\n";
                    mainText.text = temp;
                    script += temp;
                    scriptText.text = script;
                }
                resetText();
            }
        }
        enableKeep();
        

    }

    public void enableKeep()
    {
        left.gameObject.SetActive(false);
        right.gameObject.SetActive(false);
        next.gameObject.SetActive(false);
        keep.gameObject.SetActive(true);
    }
    public void enableLeftRight(string leftS, string rightS)
    {

        left.gameObject.SetActive(true);
        right.gameObject.SetActive(true);
        next.gameObject.SetActive(false);
        left.GetComponentInChildren<Text>().text = leftS;
        right.GetComponentInChildren<Text>().text = rightS;


    }


    public void rightClicked()
    {
        if (round == 1)
        {
            if (storyLine == 1)
            {
                script += "I'm not sute\n\n";
                if (playerWin)
                {
                    
                    temp = "You're a middle school math teacher, you can't count?\n\n\"Act normal, that guy over there is really a cop\"\n\n\"Well I trust the source who gave you the money so it should all be there\"\n\n ";
                    mainText.text = temp;
                    script += temp;
                }
                else
                {
                    temp = "You're ********, you can't count?\n\n\"Act normal, that guy over there is really a cop\"\n\n\"Well I trust the source who gave you the money so it should all be there\"\n\n ";
                    mainText.text = temp;
                    script += temp;

                }
                left.gameObject.SetActive(false);
                right.gameObject.SetActive(false);
                next.gameObject.SetActive(false);
                keep.gameObject.SetActive(true);
            }
            else if (storyLine == 2)
            {
                script += "I can't remember anything.\n\n";
                if (playerWin)
                {
                    temp = "\"Oh no it was the worst outcome wasn't it\"\n\n\"Do I look familiar to you, Amy?\"\n\n\"Being a software engineer was your entire world Ron, and you gave it all up\"\n\n";
                    mainText.text = temp;
                    script += temp;
                }
                else
                {
                    temp = "\"Oh no it was the worst outcome wasn't it\"\n\n\"Do I look familiar to you, ********?\"\n\n\"Being a software engineer was your entire world Ron, and you gave it all up\"\n\n";
                    mainText.text = temp;
                    script += temp;

                }
                left.gameObject.SetActive(false);
                right.gameObject.SetActive(false);
                next.gameObject.SetActive(false);
                keep.gameObject.SetActive(true);
            }
            else if (storyLine == 3)
            {
                script += "Who are you?\n\n";
                if (playerWin)
                {
                    temp = "\"As I stated before, I cannot answer that question " + green3Who[cardValue] + "\"\n\n\"I say this for the safety of your wife and children\"\n\nMy wife and children?\n\n\"Yes, don't worry we have them already and they are safe\"\n\n";
                    mainText.text = temp;
                    script += temp;
                }
                else
                {
                    temp = "\"As I stated before, I cannot answer that question " + green3Who[cardValue] + "\"\n\n\"I say this for the safety of your ********\"\n\nMy ********?\n\n\"Yes, don't worry we have them already and they are safe\"\n\n";
                    mainText.text = temp;
                    script += temp;
                }
                left.gameObject.SetActive(false);
                right.gameObject.SetActive(false);
                next.gameObject.SetActive(false);
                keep.gameObject.SetActive(true);
            }

        }
        else if (round == 2)
        {

            if (storyLine == 1)
            {
                script += "No\n\n";
                if (playerWin)
                {
                    temp = "\"I can't say too much but remember THAT THING you wanted?\"\n\n";
                    mainText.text = temp;
                    script += temp;
                }
                else
                {
                    temp = "\"I can't say too much but remember ******** you wanted?\"\n\n";
                    mainText.text = temp;
                    script += temp;

                }
                enableNext();
            }
            else if (storyLine == 2)
            {
            }
            else if (storyLine == 3)
            {
                script += "What's going on?\n\n";
                if (playerWin)
                {
                    temp = "\"You really want to discuss that here?\"\n\n\"Look you said you were in big trouble and your family needed help\"\n\n\"Something about you being tracked down by the FBI because you were involved in a huge drug ring\"\n\n\"I didn't ask too many questions because the less I know the better\"\n\n";
                    mainText.text = temp;
                    script += temp;
                }
                else
                {
                    temp = "\"You really want to ******* that here?\"\n\n\"Look you said you were in big trouble and your family needed help\"\n\n\"Something about you being tracked down by the FBI because you were involved in a huge drug ring\"\n\n\"I didn't ask too many questions because the less I know the better\"\n\n";
                    mainText.text = temp;
                    script += temp;
                }
                left.gameObject.SetActive(false);
                right.gameObject.SetActive(false);
                next.gameObject.SetActive(false);
                keep.gameObject.SetActive(true);
            }

        }
        else
        {

            if (storyLine == 1)
            {
                script += "Trust him\n\n";
                if (playerWin)
                {
                    temp = "\"Something about this man seems like I should trust him\"\n\nYou look up as a woman walks up to you in tears and hugs you.\n\n";
                    mainText.text = temp;
                    script += temp;
                }
                else
                {
                    temp = "\"Something about this man seems like I should ******** him\"\n\nYou look up as a woman walks up to you in tears and hugs you.\n\n";
                    mainText.text = temp;
                    script += temp;
                }
                enableNext();
            }
            else if (storyLine == 2)
            {
                script += "Yes\n\n";
                temp = "\"Even after the procedure, you're still a terrible liar\"\n\n\"I'm sorry, I know the doctors said I shouldn't tell you everything at once because it can be traumatizing but I can't help it\"\n\n\"I'm your " + green2How2[cardValue] + ", Amy\"\n\nI have an illness.\n\nYou decided to run a very dangerous trial experiment since it offered enough money to help me get the surgery I needed.\n\nBut...\n\nAt the cost of your memories\n\n";
                mainText.text = temp;
                script += temp;
                left.gameObject.SetActive(false);
                right.gameObject.SetActive(false);
                next.gameObject.SetActive(false);
                keep.gameObject.SetActive(true);
            }
            else if (storyLine == 3)
            {
                script += "I'm Sorry\n\n";
                temp = green3How2[cardValue] + "\n\nWith tears in her eyes, she mouths the words, \n\n\"No, I'm sorry\"\n\n\"FREEZE!!\"\n\n\"Put your hands where I can see them!\"\n\n";
                mainText.text = temp;
                script += temp;
                left.gameObject.SetActive(false);
                right.gameObject.SetActive(false);
                next.gameObject.SetActive(false);
                keep.gameObject.SetActive(true);
            }
            keep.GetComponentInChildren<Text>().text = "Retry";
            resetText();
        }
        scriptText.text = script;

    }



    public void leftClicked()
    {
        if (round == 1)
        {
            if (storyLine == 1)
            {
                script += "Yes\n\n";
                if (playerWin)
                {
                    temp = "Great, I can't believe you're paying this much for this. \n\nAct cool, remember there's, cops, all around these places. \n\nI've been told you're just a middle school teacher from a small town in Texas, how did you get this kind of money?\n\n ";
                    mainText.text = temp;
                    script += temp;
                }
                else
                {
                    temp = "Great, I can't believe you're paying this much for this. \n\nAct cool, remember there's, cops, all around these places. \n\nI've been told you're just a ******* from a small town in Texas, how did you get this kind of money?\n\n ";
                    mainText.text = temp;
                    script += temp;
                }
                left.gameObject.SetActive(false);
                right.gameObject.SetActive(false);
                next.gameObject.SetActive(false);
                keep.gameObject.SetActive(true);
            }
            else if (storyLine == 2)
            {
                script += "Yes\n\n";
                if (playerWin)
                {
                    temp = "\"You don't have to lie to protect me\"\n\n\"But why would you do such a stupid thing when you have a family\" Your kids were worried sick.\n\n\"Being a software engineer was your entire world Amy, and you gave it all up\"\n\n";
                    mainText.text = temp;
                    script += temp;
                }
                else
                {
                    temp = "\"********\"\n\n \"But why would you do such a stupid thing when you have a family\" Your kids were worried sick.\n\n\"Being a software engineer was your entire world Amy, and you gave it all up\"\n\n";
                    mainText.text = temp;
                    script += temp;
                }
                left.gameObject.SetActive(false);
                right.gameObject.SetActive(false);
                next.gameObject.SetActive(false);
                keep.gameObject.SetActive(true);
            }
            else if (storyLine == 3)
            {
                script += "Yes\n\n";
                if (playerWin)
                {
                    temp = "\"Great " + green3Who[cardValue] + ", in 10 minutes get up from this table and head outside to the back alley\"\n\n\"In the meantime, we can play a few more rounds of BlackJack until the van is ready with your family\"\n\n";
                    mainText.text = temp;
                    script += temp;
                }
                else
                {
                    temp = "\"Great " + green3Who[cardValue] + ", in 10 minutes get up from this table and head outside to the ********\"\n\n\"In the meantime, we can play a few more rounds of BlackJack until the van is ready with your family\"\n\n";
                    mainText.text = temp;
                    script += temp;

                }
                left.gameObject.SetActive(false);
                right.gameObject.SetActive(false);
                next.gameObject.SetActive(false);
                keep.gameObject.SetActive(true);
            }

        }
        else if (round == 2)
        {
            if (storyLine == 1)
            {
                script += "Yes\n\n";
                if (playerWin)
                {
                    temp = "\"I can tell you're lying\"\n\n\"Look, you came here to buy something that's technically not legal\"\n\n\"You came to me for this, so you need to act like it\"\n\n";
                    mainText.text = temp;
                    script += temp;
                }
                else
                {
                    temp = "\"I can tell you're lying\"\n\n\"Look, you came here to buy something that's ********\"\n\n\"You came to me for this, so you need to act like it\"\n\n";
                    mainText.text = temp;
                    script += temp;
                }
                enableNext();
            }
            else if (storyLine == 2)
            {

            }
            else if (storyLine == 3)
            {
                script += "Connections?\n\n";
                if (playerWin)
                {
                    temp = "\"Look you said you were in big trouble and your family needed help\"\n\n\"I'm providing that for you, just trust me and stop asking questions\"\n\n\"You told me where to pick up your family and you would come back with the money\"\n\n\"Now keep your voice down and let's play another round\"\n\n";
                    mainText.text = temp;
                    script += temp;
                }
                else
                {
                    temp = "\"Look you said you were in big trouble and your family needed help\"\n\n\"I'm providing that for you, just trust me and stop asking questions\"\n\n\"You told me where to ******** family and you would come back with the money\"\n\n\"Now keep your voice down and let's play another round\"\n\n";
                    mainText.text = temp;
                    script += temp;
                }
                left.gameObject.SetActive(false);
                right.gameObject.SetActive(false);
                next.gameObject.SetActive(false);
                keep.gameObject.SetActive(true);
            }

        }
        else
        {
            if (storyLine == 1)
            {
                script += "Ignore\n\n";
                if (playerWin)
                {
                    temp = "\"You alright man, don't worry its almost here\"\n\nAs you grab this thing under your shirt you look up to see a young woman staring back at you.\n\nShe looks familiar but...\n\n\"Freeze!\"\n\n";
                    mainText.text = temp;
                    script += temp;
                }
                else
                {
                    temp = "\"You alright man, don't worry its almost here\"\n\nAs you grab this thing under your shirt you look up to see a young woman staring back at you.\n\nShe looks familiar but...\n\n\"Freeze!\"\n\n";
                    mainText.text = temp;
                    script += temp;
                }
                enableNext();
            }
            else if (storyLine == 2)
            {
                script += "No\n\n";
                temp = "\"I'm sorry, I know the doctors said I shouldn't tell you everything at once because it can be traumatizing but I can't help it\"\n\n\"I'm your " + green2How2[cardValue] + ", Amy\"\n\nI have an illness.\n\nYou decided to run a very dangerous trial experiment since it offered enough money to help me get the surgery I needed.\n\nBut...\n\nAt the cost of your memories\n\n";
                mainText.text = temp;
                script += temp;
                left.gameObject.SetActive(false);
                right.gameObject.SetActive(false);
                next.gameObject.SetActive(false);
                keep.gameObject.SetActive(true);
            }
            else if (storyLine == 3)
            {
                script += "How are you?\n\n";
                temp = green3How2[cardValue] + "\n\nShe says something but it's muffled from her face buried into your shirt.\n\nBut as you look and notice the police surrounding you, you realize she said,\n\n\"I'm sorry\"\n\n";
                mainText.text = temp;
                script += temp;
                left.gameObject.SetActive(false);
                right.gameObject.SetActive(false);
                next.gameObject.SetActive(false);
                keep.gameObject.SetActive(true);

            }
            keep.GetComponentInChildren<Text>().text = "Retry";
            resetText();

        }
        /*        mainCamera.gameObject.SetActive(false);
                NarrativeCam.gameObject.SetActive(true);*/
        scriptText.text = script;

    }
    // Update is called once per frame
    void Update()
    {

    }
}


