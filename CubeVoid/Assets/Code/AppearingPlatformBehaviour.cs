using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearingPlatformBehaviour : MonoBehaviour
{
    public Material visableMaterial;

    private MeshRenderer mRender;

    // Start is called before the first frame update
    void Start()
    {
        mRender = GetComponent<MeshRenderer>();
        mRender.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            mRender.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
            GetComponent<Renderer>().material = visableMaterial;


        }
    }
}
