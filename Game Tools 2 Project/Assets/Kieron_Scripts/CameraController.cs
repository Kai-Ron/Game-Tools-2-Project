using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerCameraPosition;
    public Transform flyerCameraPosition;
    //public Transform playerOrientation;
    //public Transform flyerOrientation;
    public KeyCode viewKey = KeyCode.LeftAlt;

    private bool view = false;

    private void Update()
    {
        controls();
    }

    private void FixedUpdate()
    {
        if (view)
        {
            transform.position = flyerCameraPosition.position;
            transform.rotation = flyerCameraPosition.rotation;
        }
        else
        {
            transform.position = playerCameraPosition.position;
            transform.rotation = playerCameraPosition.rotation;
        }
    }

    private void controls()
    {
        if (Input.GetKeyDown(viewKey))
        {   
            view = !view;
        }
    }
}
