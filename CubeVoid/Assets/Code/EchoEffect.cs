using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoEffect : MonoBehaviour
{
    public float timeBTWSpawn;
    public float startTimeBTWSpawn;

    public GameObject echo;

    // Update is called once per frame
    public void CreateEcho()
    {
            if (timeBTWSpawn <= 0)
            {
                GameObject instance = (GameObject)Instantiate(echo, transform.position, Quaternion.identity);
                Destroy(instance, 2f);
                timeBTWSpawn = startTimeBTWSpawn;
            }
            else
            {
                timeBTWSpawn -= Time.deltaTime;
            }
    }
}
