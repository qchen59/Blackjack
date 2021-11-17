using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeepButton : MonoBehaviour
{
    public Button keep;
    public Camera mainCamera;
    public Camera NarrativeCam;
    public Button dealBtn;
    public GameObject roundOb;
    public GameObject narrative;

    public void OnMouseUp()
    {
       if(roundOb.GetComponent<RoundNumber>().getRound() == 3)
        {
            keep.GetComponentInChildren<Text>().text = "Keep Playing";
            roundOb.GetComponent<RoundNumber>().round = 0;
        }
        keep.gameObject.SetActive(false);
        NarrativeCam.gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(true);
        dealBtn.gameObject.SetActive(true);
        narrative.GetComponent<StoryLines>().playerWin = false;
    }
}
