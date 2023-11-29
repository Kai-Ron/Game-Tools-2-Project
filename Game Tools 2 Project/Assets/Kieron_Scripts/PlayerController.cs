using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float airMultiplier;

    public KeyCode jumpKey = KeyCode.Space;

    public float playerHeight;
    public LayerMask whatIsGround;
    private bool grounded;

    public Transform orientation;

    private float inputX;
    private float inputY;

    private Vector3 moveDirection;

    private Rigidbody rb;

    private bool view = false;
    public KeyCode viewKey = KeyCode.LeftAlt;

    private bool follow = false;
    public KeyCode followKey = KeyCode.RightAlt;

    public Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        Controls();
    }

    private void FixedUpdate()
    {
        Move();
        SpeedControl();

        grounded = Physics.Raycast(transform.position, Vector3.down, ((playerHeight * 0.5f) + 0.2f), whatIsGround);

        if (grounded)
        {
            rb.drag = groundDrag;
            anim.SetBool("IsJumping", false);
        }
        else
        {
            rb.drag = 0;
        }
    }

    private void Controls()
    {
        if(view && !follow)
        {
            inputX = Input.GetAxisRaw("Horizontal2");
            inputY = Input.GetAxisRaw("Vertical2");
        }
        else
        {
            inputX = Input.GetAxisRaw("Horizontal");
            inputY = Input.GetAxisRaw("Vertical");
        }

        if (Input.GetKey(jumpKey) && grounded)
        {
            Jump();
            anim.SetBool("IsJumping", true);
        }

        if (Input.GetKeyDown(viewKey))
        {   
            view = !view;
        }

        if (Input.GetKeyDown(followKey))
        {   
            follow = !follow;

        }

    }

    private void Move()
    {
        moveDirection = (orientation.forward * inputY) + (orientation.right * inputX);

        if(grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
        else if (!grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }
    }

    private void SpeedControl()
    {
        Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        float CurrentSpeed = rb.velocity.magnitude;

        if (CurrentSpeed < 0.1f)
        {
            anim.SetFloat("Speed", 0f);
        }

        else if (CurrentSpeed > 0.01f)
        {
            anim.SetFloat("Speed", 1f);
        }

        if (flatVelocity.magnitude > moveSpeed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
}
