using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerCameraPosition;
    public Transform flyerCameraPosition;
    public KeyCode viewKey = KeyCode.LeftAlt;

    private bool view = false;

    private void Update()
    {   
        controls();

        if (view)
        {
            transform.position = flyerCameraPosition.position;
        }
        else
        {
            transform.position = playerCameraPosition.position;
        }
    }

    private void controls()
    {
        if (Input.GetKey(viewKey))
        {
            view = !view;
        }
    }

}
