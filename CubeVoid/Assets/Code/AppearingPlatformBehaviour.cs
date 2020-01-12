using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearingPlatformBehaviour : MonoBehaviour
{
    public Material visableMaterial;

    private MeshRenderer mr;

    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        mr.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            mr.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
            GetComponent<Renderer>().material = visableMaterial;


        }
    }
}
