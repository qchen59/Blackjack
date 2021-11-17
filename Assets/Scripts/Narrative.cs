using Ink.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Narrative : MonoBehaviour
{
    public TextAsset inkJSON;
    private Story story;
    public Text textPrefab;
    public Button buttonPrefab;

    // Start is called before the first frame update
    void Start()
    {
        story = new Story(inkJSON.text);

        refreshUI();


    }

    void refreshUI()
    {
        //eraseUI();

        Text storyText = Instantiate(textPrefab) as Text;
        storyText.text = loadStoryChunk();
        storyText.transform.SetParent(this.transform, false);
        //Debug.Log(loadStoryChunk());

        foreach (Choice choice in story.currentChoices)
        {
            Button choiceButton = Instantiate(buttonPrefab) as Button;
            Text choiceText = buttonPrefab.GetComponentInChildren<Text>();
            choiceText.text = choice.text;
            choiceButton.transform.SetParent(this.transform, false);
            choiceButton.onClick.AddListener(delegate
            {
                chooseStoryChoice(choice);
            });


        }
    }
    void eraseUI()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            Destroy(this.transform.GetChild(i).gameObject);
        }
    }

    void chooseStoryChoice(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        refreshUI();
    }
    // Update is called once per frame
    void Update()
    {

    }

    string loadStoryChunk()
    {
        string text = "";

        if (story.canContinue)
        {
            text = story.ContinueMaximally();
        }
        return text;
    }

    public static implicit operator Narrative(GameObject v)
    {
        throw new NotImplementedException();
    }
}
