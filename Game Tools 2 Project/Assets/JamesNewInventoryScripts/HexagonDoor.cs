using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonDoor : MonoBehaviour
{
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

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("CorrectHexagon"))
        {
            Destroy(gameObject);

        }
    }
}
