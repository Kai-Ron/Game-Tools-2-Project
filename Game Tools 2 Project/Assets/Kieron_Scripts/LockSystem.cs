using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockSystem : MonoBehaviour
{
    public float distance = 2.5f;
    public LayerMask playerLayerMask;
    public GameObject ui;

    public KeyCode viewKey = KeyCode.LeftAlt;
    private bool view = false;
    private bool atLock = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(viewKey))
        {   
            view = !view;
        }

        if (!view)
        {
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, distance, playerLayerMask))
            {
                //ui.SetActive(true);
                atLock = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else if (atLock)
            {
                atLock = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            /*else
            {
                //ui.SetActive(false);

                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }*/
        }
    }
}
