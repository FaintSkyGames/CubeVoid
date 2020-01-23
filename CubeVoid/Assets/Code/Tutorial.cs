﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorialTxt1;
    public GameObject tutorialTxt2 = null;
    public GameObject tutorialBox;

    private void OnTriggerEnter(Collider other)
    {
        if (PlayerPrefs.GetString("ShowTutorialText") == "Yes")
        {
            if (PlayerPrefs.GetInt("Stars Collected") != 0)
            {
                if (tutorialTxt2 != null)
                {
                    tutorialTxt2.SetActive(true);
                }
                else
                {
                    tutorialTxt1.SetActive(true);
                }
            }
            else
            {
                tutorialTxt1.SetActive(true);
            }

            tutorialBox.SetActive(true);
        }
        else
        {
            tutorialTxt1.SetActive(false);
            tutorialTxt2.SetActive(false);
            tutorialBox.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (PlayerPrefs.GetString("ShowTutorialText") == "Yes")
        {
            tutorialTxt1.SetActive(false);

            if (tutorialTxt2 != null)
            {
                tutorialTxt2.SetActive(false);
            }

            tutorialBox.SetActive(false);
        }
        else
        {
            tutorialTxt1.SetActive(false);
            tutorialTxt2.SetActive(false);
            tutorialBox.SetActive(false);
        }
    }


}
