using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class DirtScript : MonoBehaviour
{
    public GameObject UseShovelText;

    [SerializeField] InventoryManager.AllItems _requiredItem;

    public bool HasRequiredItem(InventoryManager.AllItems itemRequired)
    {
        if (InventoryManager.Instance._inventoryItems.Contains(itemRequired))
        {
            return true;

        }

        else
        {
            return false;
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            UseShovelText.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {

                UseShovel();
                UseShovelText.SetActive(false);

            }
        }
    }

    private void UseShovel()
    {
        Destroy(gameObject);
        //please work
    }
}
