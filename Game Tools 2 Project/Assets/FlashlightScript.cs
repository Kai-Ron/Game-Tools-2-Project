using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlashlightScript : MonoBehaviour
{
    public GameObject PlayerFlashlight;

    // Start is called before the first frame update
    void Start()
    {
        PlayerFlashlight.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                this.gameObject.SetActive(false);
                PlayerFlashlight.SetActive(true);
            }
        }
    }
}
