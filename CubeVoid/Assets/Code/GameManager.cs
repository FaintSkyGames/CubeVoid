using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject controls = null;

    public void StartGame()
    {
        PlayerPrefs.SetInt("Stars Collected", 0);
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame()
    {
        PlayerPrefs.SetInt("Stars Collected", 0);
        Application.Quit();
    }

    public void ShowControls()
    {
        if (controls != null)
        {
            if (controls.active == false)
            {
                controls.active = true;
            }
            else
            {
                controls.active = false;
            }
        }        
    }

    public void BackToMenu()
    {
        PlayerPrefs.SetInt("Stars Collected", 0);
        SceneManager.LoadScene("TitleScreen");
    }
}
