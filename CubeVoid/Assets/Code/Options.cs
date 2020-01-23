using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public GameObject controls;
    public GameObject settings;
    public GameObject colours;

    public GameObject blocks;

    public Toggle tutorialText;

    private void Start()
    {

        if (PlayerPrefs.GetString("ShowTutorialText") == "Yes")
        {
            Debug.Log(PlayerPrefs.GetString("ShowTutorialText"));
            tutorialText.isOn = true;
        }

    }

    public void ShowControls()
    {
        controls.SetActive(true);
        settings.SetActive(false);
        colours.SetActive(false);
        blocks.SetActive(false);
    }
    public void ShowColours()
    {
        controls.SetActive(false);
        settings.SetActive(false);
        colours.SetActive(true);
        blocks.SetActive(true);
    }
    public void ShowSettings()
    {
        controls.SetActive(false);
        settings.SetActive(true);
        colours.SetActive(false);
        blocks.SetActive(false);
    }

    public void SetTutorialPreferance()
    {
        if (PlayerPrefs.GetString("ShowTutorialText") == "Yes")
        {
            Debug.Log("yes to no");
            PlayerPrefs.SetString("ShowTutorialText", "No");
        }
        else
        {
            Debug.Log("no to yes");
            PlayerPrefs.SetString("ShowTutorialText", "Yes");
        }
    }





}
