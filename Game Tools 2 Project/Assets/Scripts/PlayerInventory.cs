using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class PlayerInventory : MonoBehaviour
{

    public InventoryObject inventory;
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<GroundItem>();
        if (item)
        {
            inventory.AddItem(new Item(item.item), 1);
            Destroy(other.gameObject);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            inventory.Save();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            inventory.Load();
        }
    }

    private void OnApplicationQuit()
    {
        inventory.Container.Items.Clear();
    }
}
*/ 