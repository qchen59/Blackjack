using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeepButton : MonoBehaviour
{
    public Button keep;
    public Camera mainCamera;
    public Camera NarrativeCam;

    public void OnMouseUp()
    {
        keep.gameObject.SetActive(false);
        NarrativeCam.gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(true);
    }
}
