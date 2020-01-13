using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject controls = null;

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame()
    {
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
}
