using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightScript : MonoBehaviour
{
    private Light flashlight;
    private float minAngle = 0f;
    private float maxAngle = 30f;
    private bool IsMaxing = false;

    private void Start()
    {
        flashlight = GetComponentInChildren<Light>();
        flashlight.enabled = false;
        flashlight.spotAngle = minAngle;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && IsMaxing == false)
        {
            flashlight.enabled = !flashlight.enabled;
            flashlight.spotAngle = maxAngle;
            IsMaxing = true;
        }

        else if(Input.GetKeyDown(KeyCode.F) && IsMaxing == true)
        {
            flashlight.spotAngle = minAngle;
            IsMaxing = false;
            flashlight.enabled = false;
        }
    }
}