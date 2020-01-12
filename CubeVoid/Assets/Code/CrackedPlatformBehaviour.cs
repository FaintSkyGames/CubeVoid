﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackedPlatformBehaviour : MonoBehaviour
{
    public float secondsToWait = 3;

    private MeshRenderer mRender;
    private BoxCollider bCollider;

    // Start is called before the first frame update
    void Start()
    {
        mRender = GetComponent<MeshRenderer>();
        mRender.enabled = true;
        bCollider = GetComponent<BoxCollider>();
        bCollider.enabled = true;
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

        mRender.enabled = false;
        bCollider.enabled = false;
    }


}