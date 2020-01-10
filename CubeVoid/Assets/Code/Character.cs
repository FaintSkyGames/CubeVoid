using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float speed = 3;
    public float jumpHeight = 2;
    private Vector3 playerInputs = Vector3.zero;
    private Rigidbody rb;

    public int maxJumps = 1;
    public bool isGrounded = true;
    private int jumpsRemaining;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpsRemaining = maxJumps;
    }

    // Update is called once per frame
    void Update()
    {
        playerInputs = Vector3.zero;

        playerInputs.x = Input.GetAxis("Horizontal");
        ChangeZAxis();

        rb.MovePosition(rb.position + playerInputs * speed * Time.fixedDeltaTime);

    }

    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void ChangeZAxis()
    {
        Vector3 targetZAxis = Vector3.zero;

        if (Input.GetKeyDown("w") && rb.position.z < 1)
        {
            targetZAxis.Set(0, 0, 1);
        }
        if (Input.GetKeyDown("s") && rb.position.z > -1)
        {
            targetZAxis.Set(0, 0, -1);
        }

        rb.MovePosition(rb.position + targetZAxis);
    }

    private void Jump()
    {
        if (isGrounded)
        {
            Debug.Log("jumpped");
            rb.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
            isGrounded = false;
        }
        else if (jumpsRemaining > 0)
        {
            Debug.Log("second jump");
            rb.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
            isGrounded = false;
            jumpsRemaining -= 1;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
        jumpsRemaining = maxJumps;
    }
}
