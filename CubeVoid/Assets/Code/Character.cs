using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    //Raycasting
    public float raycastTargetDistance;
    private RaycastHit baseHit; //To prevent recalculating

    //Jump variables
    public float jumpHeight = 2;
    public int maxJumps = 1;
    private int jumpsRemaining;

    public float speed = 3;

    //Status variables
    public bool isGrounded = true;
    public bool groundPound = false;

    private Rigidbody rb;
    private Vector3 playerInputs = Vector3.zero;
    public bool canMove = true; //To prevent movement when paused

    //Non player
    public GameObject spawnPoint;

    //Visual
    private Animator anim;
    private CameraShake shake;
    public ParticleSystem splashLanding;
    public ParticleSystem splashLandingHeavy;
    private EchoEffect echo;
    private bool heavyAnimation = false;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        echo = GetComponent<EchoEffect>();

        shake = GameObject.FindGameObjectWithTag("shake").GetComponent<CameraShake>();

        AnimationClip clip;

        //Get jump and animation to happen at same time
        AnimationEvent jump;
        jump = new AnimationEvent();
        jump.functionName = "AddForceToJump";
        anim = GetComponent<Animator>();
        clip = anim.runtimeAnimatorController.animationClips[1];
        clip.AddEvent(jump);

        //Get in world effects and player animation to happen at same time
        AnimationEvent impact;
        impact = new AnimationEvent();
        impact.functionName = "Impact";
        anim = GetComponent<Animator>();
        clip = anim.runtimeAnimatorController.animationClips[3];
        clip.AddEvent(impact);

    }

    private void Update()
    {
        if (canMove)
        {

            Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out baseHit);
            raycastTargetDistance = baseHit.distance;

            SetGrounded(baseHit);

            //Get inputs
            playerInputs = Vector3.zero;
            playerInputs.x = Input.GetAxis("Horizontal");

            //Adjust position
            ChangeZAxis();

            //Perform special moves
            if (Input.GetButtonDown("Jump")) { Jump(); }
            if (Input.GetKeyDown(KeyCode.LeftShift)) { Pound(); }
            if (Input.GetKeyDown("r")) { Respawn(); }

        }
    }

    //Move player
    //In here for camera to way it should
    private void FixedUpdate()
    {
        if (canMove)
        {
            rb.MovePosition(rb.position + playerInputs * speed * Time.fixedDeltaTime);
            echo.CreateEcho();
        }
    }

    void SetGrounded(RaycastHit hit)
    {
        if (hit.distance <= 0.4f)
        {
            isGrounded = true;
            anim.SetBool("isJumping", false);
        }
        else
        {
            isGrounded = false;
            anim.SetBool("isJumping", true);
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
        RaycastHit jumpHit;
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out jumpHit);
        SetGrounded(jumpHit);

        if (isGrounded)
        {
            splashLanding.Play();
            anim.SetTrigger("takeOff");
            isGrounded = false;
            rb.MovePosition(rb.position + new Vector3(0, 0.2f, 0)); //Prevent issue with raycast
        }
        else if (jumpsRemaining > 0)
        {
            splashLanding.Play();
            anim.SetTrigger("takeOff");
            jumpsRemaining -= 1;
        }
    }

    private void Pound()
    {
        if (!isGrounded)
        {
            groundPound = true;
            heavyAnimation = true;
            AddForceToFall();
        }
    }

    private void Respawn()
    {
        rb.transform.position = spawnPoint.transform.position;
    }

    public void AddForceToJump()
    {
        rb.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
    }

    public void AddForceToFall()
    {
        rb.AddForce(Vector3.down * Mathf.Sqrt(-6f * Physics.gravity.y), ForceMode.VelocityChange);
    }

    //On collision respawn, break blocks or gain jumps
    private void OnCollisionEnter(Collision collision)
    {
        if (groundPound == true)
        {
            //Will not always have a reciever
            collision.gameObject.SendMessage("GroundPound");
            groundPound = false;
        }

        RaycastHit colliderHit;
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out colliderHit);
        SetGrounded(colliderHit);
        if (isGrounded)
        {
            jumpsRemaining = maxJumps;
        }

        if (collision.gameObject.tag == "Respawn")
        {
            spawnPoint = collision.gameObject;
        }
    }

    //How to move camera and particles on impact
    public void Impact()
    {
        if (heavyAnimation)
        {
            shake.CamHeavyShake();
            splashLandingHeavy.Play();
            heavyAnimation = false;
        }
        else
        {
            shake.CamShake();
            splashLanding.Play();
        }
    }
}
