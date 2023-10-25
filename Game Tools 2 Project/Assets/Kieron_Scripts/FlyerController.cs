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

    private bool view = false, follow;

    public KeyCode viewKey = KeyCode.LeftAlt;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        Controls();
        SpeedControl();

        rb.drag = drag;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Controls()
    {
        inputX = Input.GetAxisRaw("Horizontal2");
        inputZ = Input.GetAxisRaw("Vertical2");
        inputY = Input.GetAxisRaw("Jump2");

        if (Input.GetKeyDown(viewKey))
        {   
            view = !view;
        }
    }

    private void Move()
    {
        if(follow)
        {
            if(inputX == 0)
            {
                inputX = Input.GetAxisRaw("Horizontal");
            }

            if(inputZ == 0)
            {
                inputZ = Input.GetAxisRaw("Vertical");
            }
        }
        
        moveDirection = (orientation.forward * inputZ) + (orientation.up * inputY) + (orientation.right * inputX);
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVelocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z);

        if (flatVelocity.magnitude > moveSpeed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVelocity.x, limitedVelocity.y, limitedVelocity.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            follow = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            follow = false;
        }
    }
}
