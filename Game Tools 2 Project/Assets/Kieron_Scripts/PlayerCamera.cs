using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float sensX, sensY/*, sensZ*/;
    private float rotX, rotY/*, zoom*/;
    private float playerX = 0, playerY = 0, flyerX = 0, flyerY = 0;
    public Transform playerOrientation;
    public Transform flyerOrientation;
    public Transform playerPos;
    public Transform flyerPos;

    private bool view = false;
    public KeyCode viewKey = KeyCode.LeftAlt;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        controls();

        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;
        //float mouseZ = Input.GetAxisRaw("Mouse Scroll Wheel") * Time.deltaTime * sensZ;

        //zoom += mouseZ;
        //zoom = Mathf.Clamp(zoom, 3, 9);

        if (view)
        {
            rotY += mouseX;
            rotX += mouseY;

            rotX = Mathf.Clamp(rotX, -45f, 45f);
            
            //transform.rotation = Quaternion.Euler(rotX, rotY, 0);

            flyerPos.localEulerAngles = new Vector3(rotX, rotY, 0);
            //transform.localEulerAngles = new Vector3(rotX, rotY, 0);

            playerOrientation.rotation = Quaternion.Euler(0, rotY, 0);

            flyerPos.position = playerPos.position + flyerPos.forward;
        }
        else
        {
            rotY += mouseX;
            rotX -= mouseY;

            rotX = Mathf.Clamp(rotX, -90f, 90f);
            
            transform.rotation = Quaternion.Euler(rotX, rotY, 0);

            flyerOrientation.rotation = Quaternion.Euler(0, rotY, 0);
            playerOrientation.rotation = Quaternion.Euler(0, rotY, 0);
        }
    }

    private void controls()
    {
        if (Input.GetKeyDown(viewKey))
        {   
            if(view)
            {
                flyerX = rotX;
                flyerY = rotY;
                rotX = playerX;
                rotY = playerY;
            }
            else
            {
                playerX = rotX;
                playerY = rotY;
                rotX = flyerX;
                rotY = flyerY;
            }

            view = !view;
        }
    }
}
