using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
<<<<<<< Updated upstream
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
=======
    public float sensY;
    public float sensX;

    public Transform orientation;

    float yRotation;
    float xRotation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        xRotation += mouseY;

        yRotation += mouseX;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

>>>>>>> Stashed changes
    }

}
