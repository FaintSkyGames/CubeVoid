using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatformBehaviour : MonoBehaviour
{
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
            mr.enabled = false;
            bc.enabled = false;
        }
    }
}
