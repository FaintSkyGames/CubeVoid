using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatformBehaviour : MonoBehaviour
{
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
            mRender.enabled = false;
            bCollider.enabled = false;
        }
    }
}
