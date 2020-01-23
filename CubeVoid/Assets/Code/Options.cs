using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    public GameObject controls;
    public GameObject settings;
    public GameObject colours;

    public GameObject blocks;

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



}
