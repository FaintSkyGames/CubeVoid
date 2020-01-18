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

    public GameObject spawnPoint;

    public bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        jumpsRemaining = maxJumps;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            playerInputs = Vector3.zero;

            playerInputs.x = Input.GetAxis("Horizontal");
            ChangeZAxis();

            //rb.MovePosition(rb.position + playerInputs * speed * Time.fixedDeltaTime);

            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }

            if (Input.GetKeyDown("r"))
            {
                Respawn();
            }

            //Debug.Log(isGrounded);

        }

    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            rb.MovePosition(rb.position + playerInputs * speed * Time.fixedDeltaTime);
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
            rb.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
            isGrounded = false;
        }
        else if (jumpsRemaining > 0)
        {
            rb.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
            isGrounded = false;
            jumpsRemaining -= 1;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
        jumpsRemaining = maxJumps;

        if (collision.gameObject.tag == "Respawn")
        {
            spawnPoint = collision.gameObject;
        }
    }

    public void Respawn()
    {
        rb.transform.position = spawnPoint.transform.position;
    }
}
