using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject levelSelector = null;
    public GameObject mainMenu = null;
    public GameObject pauseMenu = null;
    public bool paused = false;
    public GameObject player = null;

    public void Start()
    {
        this.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Volume");
    }

    public void QuitGame()
    {
        PlayerPrefs.SetInt("Stars Collected", 0);
        Application.Quit();
    }

    public void ShowControls()
    {
        SceneManager.LoadScene("Options");
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
                pauseMenu.SetActive(paused);

                player.GetComponent<Character>().canMove = !paused;
            }
        }
    }

    public void Resume()
    {
        paused = false;
        pauseMenu.SetActive(paused);
    }

    public void SelectLevel()
    {
        levelSelector.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void Back()
    {
        levelSelector.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void PlayLevel1()
    {
        PlayerPrefs.SetInt("Stars Collected", 0);
        SceneManager.LoadScene("Level1");
    }
    public void PlayLevel2()
    {
        PlayerPrefs.SetInt("Stars Collected", 0);
        SceneManager.LoadScene("Level2");
    }
}
