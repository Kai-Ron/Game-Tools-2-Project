using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    [SerializeField] InventoryManager.AllItems _itemType;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            InventoryManager.Instance.AddItem(_itemType);

        }
    }
    
        public GameObject PickUpText;

    

    private void Start()
    {
        PickUpText.SetActive(false);
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            PickUpText.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {

                //PickUp();
                PickUpText.SetActive(false);

            }

        }

    }
}
