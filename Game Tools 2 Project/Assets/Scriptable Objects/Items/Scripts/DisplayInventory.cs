using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
/*
public class DisplayInventory : MonoBehaviour
{
    public GameObject inventoryPrefab;
    public int xStart;
    public int yStart;
    public InventoryObject inventory;
    public int xSpaceBetweenItems;
    public int numberOfColumns;
    public int ySpaceBetweenItems;
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();
    // Start is called before the first frame update
      void Start()
     {
         CreateDisplay();
     }

      void Update()
     {
        UpdateDisplay();
     }

     public void UpdateDisplay()
     {
         for(int i = 0; i < inventory.Container.Items.Count; i++) 
         {
            InventorySlot slot = inventory.Container.Items[i];

             if (itemsDisplayed.ContainsKey(slot))
             {
                 itemsDisplayed[slot].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container.Items[i].amount.ToString("n0");
             }
             else
             {
                 var obj = Instantiate(inventoryPrefab, Vector3.zero, Quaternion.identity, transform);
                 obj.transform.GetChild(0).GetComponentInChildren<Image>().sprite = inventory.database.GetItem[slot.item.Id].uiDisplay;
                 obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                 obj.GetComponentInChildren<TextMeshProUGUI>().text = slot.amount.ToString("n0");
                 itemsDisplayed.Add(slot, obj);
             }
         }
     }

     public void CreateDisplay()
     {
         for(int i = 0; i < inventory.Container.Items.Count; i++) 
         {
             InventorySlot slot = inventory.Container.Items[i];

             var obj = Instantiate(inventoryPrefab, Vector3.zero, Quaternion.identity, transform);
             obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
             obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container.Items[i].amount.ToString("n0");
             itemsDisplayed.Add(slot, obj);
         }
     }

     public Vector3 GetPosition(int i)
     {
         return new Vector3(xStart + (xSpaceBetweenItems * (i % numberOfColumns)), yStart + (-ySpaceBetweenItems * (i/numberOfColumns)), 0f);
     }


 }

*/