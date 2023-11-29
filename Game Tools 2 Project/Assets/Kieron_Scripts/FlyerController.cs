using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyerController : MonoBehaviour
{
    public float moveSpeed;

    public float drag;

    public float playerHeight;

    public Transform orientation;
    public Transform playerPos;

    private float inputX;
    private float inputY;
    private float inputZ;

    private Vector3 moveDirection;

    private Rigidbody rb;

    private bool view = false;
    public KeyCode viewKey = KeyCode.LeftAlt;

    private bool follow = false;
    public KeyCode followKey = KeyCode.RightAlt;

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

        rb.drag = drag;
    }

    private void Controls()
    {
        if(view && !follow)
        {
            inputX = Input.GetAxisRaw("Horizontal");
            inputZ = Input.GetAxisRaw("Vertical");
            inputY = Input.GetAxisRaw("Jump");
        }
        else
        {
            inputX = Input.GetAxisRaw("Horizontal2");
            inputZ = Input.GetAxisRaw("Vertical2");
            inputY = Input.GetAxisRaw("Jump2");
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
        if(!follow)
        {
            moveDirection = (orientation.forward * inputZ) + (orientation.up * inputY) + (orientation.right * inputX);
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
    }

    private void SpeedControl()
    {
        if(!follow)
        {
            Vector3 flatVelocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z);

            if (flatVelocity.magnitude > moveSpeed)
            {
                Vector3 limitedVelocity = flatVelocity.normalized * moveSpeed;
                rb.velocity = new Vector3(limitedVelocity.x, limitedVelocity.y, limitedVelocity.z);
            }
        }
    }
}
