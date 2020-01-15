using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnStarCollect : MonoBehaviour
{
    public int totalStars = 0;
    public GameObject stars;
    private bool allCollected = false;

    public GameManager gameSystem;

    //public GameObject txt;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (allCollected == false)
        {
            if (PlayerPrefs.GetInt("Stars Collected") != 0)
            {
                for (int i = 0; i < PlayerPrefs.GetInt("Stars Collected"); i++)
                {
                    stars.transform.GetChild(i).gameObject.SetActive(true);
                }
            }

            if (PlayerPrefs.GetInt("Stars Collected") == totalStars)
            {
                allCollected = true;
            }

            //Debug.Log(PlayerPrefs.GetInt("Stars Collected"));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && allCollected == true)
        {
            gameSystem.BackToMenu();
            //Debug.Log("EndGame");
        }
    }

}
