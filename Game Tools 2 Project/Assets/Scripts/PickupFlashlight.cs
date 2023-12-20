using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupFlashlight : MonoBehaviour
{
    [SerializeField] InventoryManager.AllItems _itemType;

    public GameObject PickUpText;
    public GameObject PlayerFlashlight;
    private FlashlightScript flashlightScript;

    private void Start()
    {
        PickUpText.SetActive(false);
        PlayerFlashlight.SetActive(false);
        flashlightScript = PlayerFlashlight.GetComponent<FlashlightScript>();
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            PickUpText.SetActive(true);
            Debug.Log("Detects player is there");
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("E Pressed");
                PlayerFlashlight.SetActive(true);
                flashlightScript.LightOn();
                PickUpText.SetActive(false);
                PickUp();
                Destroy(gameObject);

            }
        }
    }


    public void PickUp()
    {
        InventoryManager.Instance.AddItem(_itemType);
        this.gameObject.SetActive(false);
    }
}
