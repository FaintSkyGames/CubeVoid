using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackedPlatformBehaviour : MonoBehaviour
{
    public float secondsToWait = 3;

    private MeshRenderer mr;
    private BoxCollider bc;

    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        mr.enabled = true;
        bc = GetComponent<BoxCollider>();
        bc.enabled = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(StartCrumble());
        }
    }

    IEnumerator StartCrumble()
    {
        yield return new WaitForSeconds(secondsToWait);

        mr.enabled = false;
        bc.enabled = false;
    }


}
