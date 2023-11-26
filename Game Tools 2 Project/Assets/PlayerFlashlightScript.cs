using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlashlightScript : MonoBehaviour
{
    Light lightBeam;
    private void Start()
    {
        lightBeam = GetComponent<Light>();
        lightBeam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {

            lightBeam.enabled = !lightBeam.enabled;

        }
    }
}
