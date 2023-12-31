using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    [SerializeField] InventoryManager.AllItems _itemType;
    
        public GameObject PickUpText;
        public GameObject RoomDoor;
        public GameObject GardenDoor;

    private void Start()
    {
        PickUpText.SetActive(false);
        RoomDoor.SetActive(true);
        GardenDoor.SetActive(false);
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            PickUpText.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {

                PickUp();
                PickUpText.SetActive(false);

            }

        }


    }

    public void PickUp()
    {
        InventoryManager.Instance.AddItem(_itemType);
        RoomDoor.SetActive(false);
        GardenDoor.SetActive(true);
        this.gameObject.SetActive(false);


    }
}
