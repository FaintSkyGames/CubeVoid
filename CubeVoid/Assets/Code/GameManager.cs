using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject controls = null;

    public GameObject pauseMenu = null;
    public bool paused = false;
    public GameObject player = null;


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

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused == false)
            {
                paused = true;
            }
            else
            {
                paused = false;
            }

            if (pauseMenu != null)
            {
                pauseMenu.active = paused;

                player.GetComponent<Character>().canMove = !paused;
            }
        }
    }

    public void Resume()
    {
        paused = false;
        pauseMenu.active = paused;
    }
}
