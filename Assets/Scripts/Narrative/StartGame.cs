using UnityEngine;
using System.Collections;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public Button startBtn;
    public Text btnText;
    public bool start = false;
    public bool start2 = false;

    //public bool clicked = false;
    public int click = -1;
    public GameObject title;
    public GameObject logo;
    public GameObject NarativeCanvas;
    public Text contentNote;
    public Text NarrativeText;

    public string[] contentList = new string[] {"The sounds of the busy street wake you up where you find yourself laying on a sidewalk.$$\"What am I doing here.\"", "A person walks up next to you and asks,$$\"Hey, buddy are you ok? What's your name, do you need me to call someone for you\"$$You realize you don't know your name. The helping pedestrian in confusion walks off."
    ,"You notice a suitcase in your hand.$$You feel weak but you are able to prop yourself up and open to finding it filled to the brim with money.",
    "There is a note at the top.$$\"Play Blackjack with a man wearing a Gucci basketball hat in the Casino.\"$$You turn around to see a huge casino. As you walk in you see the man." };
    // Use this for initialization
    void Start()
    {
        startBtn.onClick.AddListener(() => StartClick());

    }

    private void updateText()
    {
        String temp = "";
        if(click == 0)
        {
            temp = "The sounds of the busy street wake you up where you find yourself laying on a sidewalk.$$\"What am I doing here.\"";
        } else if (click == 1)
        {
            temp = "A person walks up next to you and asks,$$\"Hey, buddy are you ok? What's your name, do you need me to call someone for you\"$$You realize you don't know your name. The helping pedestrian in confusion walks off.";
        } else if (click == 2)
        {
            temp = "You notice a suitcase in your hand.$$You feel weak but you are able to prop yourself up and open to finding it filled to the brim with money.";
        } else if (click == 3)
        {
            temp = "There is a note at the top.$$\"Play Blackjack with a man wearing a Gucci basketball hat in the Casino.\"$$You turn around to see a huge casino. As you walk in you see the man.";
        }

        NarrativeText.text = temp.Replace("$", "\n");
    }

    private void StartClick()
    {
        if (!start)
        {
            title.gameObject.SetActive(false);
            logo.gameObject.SetActive(false);
            contentNote.gameObject.SetActive(true);
            start = true;
            click++;
        }
        else if (start && click >= 0 && click < 3)
        {
            contentNote.gameObject.SetActive(false);
            NarrativeText.gameObject.SetActive(true);
            updateText();
            click++;
            btnText.text = "Continue";
        }
        else if (start && click == 3)
        {
            updateText();
            btnText.text = "Go play";
            start2 = true;
            click++;

        }else if (start2 && click == 4)
        {
            NarativeCanvas.gameObject.SetActive(false);
            SceneManager.LoadScene(1);
          
    }
        //clicked = true;




    }

    // Update is called once per frame
    void Update()
    {

    }
}
