using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightScript : MonoBehaviour
{
    private Light flashlight;
    private float minAngle = 0f;
    public float maxAngle = 40f;
    public bool hasFlashlight = false;

    private bool view = false;
    public KeyCode viewKey = KeyCode.LeftAlt;

    private void Start()
    {
        flashlight = GetComponentInChildren<Light>();
        flashlight.enabled = false;
        flashlight.spotAngle = minAngle;
    }

    private void Update()
    {
        controls();
        
        if(view & hasFlashlight)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            flashlight.spotAngle = minAngle;
            flashlight.enabled = false;
        }
        else if (hasFlashlight)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            flashlight.enabled = true;
            flashlight.spotAngle = maxAngle;
        }
    }

    public void LightOn()
    {
        if(view)
        {
            hasFlashlight = true;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            flashlight.spotAngle = minAngle;
            flashlight.enabled = false;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            flashlight.enabled = !flashlight.enabled;
            flashlight.spotAngle = maxAngle;
            hasFlashlight = true;
        }
    }

    private void controls()
    {
        if (Input.GetKeyDown(viewKey))
        {   
            if(view && hasFlashlight)
            {
                gameObject.GetComponent<MeshRenderer>().enabled = true;
                flashlight.enabled = !flashlight.enabled;
                flashlight.spotAngle = maxAngle;
            }
            else if (hasFlashlight)
            {
                flashlight.spotAngle = minAngle;
                flashlight.enabled = !flashlight.enabled;
                gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
            view = !view;
        }
    }
}