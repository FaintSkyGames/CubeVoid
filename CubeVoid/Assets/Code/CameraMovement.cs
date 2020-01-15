using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    private Vector3 offset;
    private Vector3 oppositeZValue;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        oppositeZValue = new Vector3(0, 0, player.transform.position.z);
        //transform.position = player.transform.position + offset - oppositeZValue;
        transform.position = Vector3.Slerp(player.transform.position + offset - oppositeZValue, transform.position, 0.95f);
    }
}
