using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float sensX, sensY, sensZ;
    private float rotX, rotY, zoom;
    private float playerX = 0, playerY = 0, flyerX = 0, flyerY = 0, flyerZ;
    public Transform playerOrientation;
    public Transform flyerOrientation;
    public Transform playerPos;
    public Transform flyerPos;
    public GameObject pauseScreen;

    private bool view = false;
    public KeyCode viewKey = KeyCode.LeftAlt;
    private bool follow = false;
    public KeyCode followKey = KeyCode.RightAlt;
    private bool pause = false;
    public KeyCode pauseKey = KeyCode.Tab;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        controls();
    }

    void FixedUpdate()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;
        float mouseZ = Input.GetAxisRaw("Mouse Scroll Wheel") * Time.deltaTime * sensZ;

        if (view && follow)
        {
            rotY += mouseX;
            rotX -= mouseY;
            zoom -= mouseZ;

            zoom = Mathf.Clamp(zoom, 3, 9);
            rotX = Mathf.Clamp(rotX, 0, 90f);
            
            //transform.LookAt(playerPos);
            flyerPos.LookAt(playerPos);
            flyerPos.rotation = Quaternion.Euler(rotX, rotY, 0);

            //flyerPos.localEulerAngles = new Vector3(rotX, rotY, 0);
            //flyerOrientation.localEulerAngles = new Vector3(rotX, rotY, 0);
            //transform.localEulerAngles = new Vector3(rotX, rotY, 0);

            playerOrientation.rotation = Quaternion.Euler(0, rotY, 0);
            flyerPos.position = playerPos.position - (flyerPos.forward * zoom);
        }
        else
        {
            if(follow)
            {
                flyerPos.position = playerPos.position + (playerPos.up * 2) ;
            }
            
            rotY += mouseX;
            rotX -= mouseY;

            rotX = Mathf.Clamp(rotX, -90f, 90f);
            
            transform.rotation = Quaternion.Euler(rotX, rotY, 0);

            flyerOrientation.rotation = Quaternion.Euler(0, rotY, 0);
            playerOrientation.rotation = Quaternion.Euler(0, rotY, 0);
        }
    }

    public void Unpause()
    {
        pauseScreen.SetActive(false);
        pause = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void controls()
    {
        if(Input.GetKeyDown(pauseKey))
        {
            if(pause)
            {
                pauseScreen.SetActive(false);
                pause = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                pauseScreen.SetActive(true);
                pause = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
        
        if (Input.GetKeyDown(viewKey))
        {   
            //flyerPos.LookAt(playerPos);
            transform.rotation = Quaternion.Euler(0,0,0);

            if(view && !follow)
            {
                flyerX = rotX;
                flyerY = rotY;
                flyerZ = zoom;
                rotX = playerX;
                rotY = playerY;
            }
            else if(view)
            {
                flyerX = rotX; // original: flyerX = rotY;
                flyerY = rotY;
                flyerZ = zoom;
            }
            else if (!follow)
            {
                playerX = rotX;
                playerY = rotY;
                rotX = flyerX;
                rotY = flyerY;
                zoom = flyerZ;
            }
            else
            {
                playerX = rotX;
                playerY = rotY;
                zoom = flyerZ;
            }
            view = !view;
        }

        if (Input.GetKeyDown(followKey))
        {   
            //flyerPos.LookAt(playerPos);

            if(view && !follow)
            {
                //transform.rotation = Quaternion.Euler(0,0,0);
                rotX = 0;
                rotY = 0;
                zoom = flyerZ;
                transform.rotation = flyerPos.rotation;
                flyerPos.position = playerPos.position - (flyerPos.forward * zoom);
            }
            else if(!follow)
            {
                flyerX = 0;
                flyerY = 0;
            }
            else if(view)
            {
                flyerX = rotX;
                flyerY = rotY;
                flyerZ = zoom;
            }
            //flyerPos.LookAt(playerPos);

            follow = !follow;
        }
    }
}