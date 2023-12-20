using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightScript : MonoBehaviour
{
    private Light flashlight;
    private float minAngle = 0f;
    public float maxAngle = 40f;

    private void Start()
    {
        flashlight = GetComponentInChildren<Light>();
        flashlight.enabled = false;
        flashlight.spotAngle = minAngle;
    }

    public void LightOn()
    {
        flashlight.enabled = !flashlight.enabled;
        flashlight.spotAngle = maxAngle;
    }
}