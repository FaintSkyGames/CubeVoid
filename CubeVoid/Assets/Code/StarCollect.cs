using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollect : MonoBehaviour
{
    private bool collected = false;

    private MeshRenderer mRender;
    private MeshCollider mCollider;

    // Start is called before the first frame update
    void Start()
    {
        mRender = GetComponent<MeshRenderer>();
        mRender.enabled = true;
        mCollider = GetComponent<MeshCollider>();
        mCollider.enabled = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            mRender.enabled = false;
            mCollider.enabled = false;

            collected = true;
            PlayerPrefs.SetInt("Stars Collected", PlayerPrefs.GetInt("Stars Collected") + 1);
            //gameObject.SendMessage("StarCollected");
        }
    }

    public bool GetCollectStaus()
    {
        return collected;
    }

   
}
