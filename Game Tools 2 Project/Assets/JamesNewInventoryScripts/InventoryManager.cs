using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<AllItems> _inventoryItems = new List<AllItems>(); //New Inventory list

    private void Awake()
    {
        Instance = this;
    }

    public void AddItem(AllItems item) //Add Items
    {
        if(!_inventoryItems.Contains(item))
        {
            _inventoryItems.Add(item);
        }
    }

    public void RemoveItem(AllItems item) //Remove Items
    {
        if (_inventoryItems.Contains(item))
        {
            _inventoryItems.Remove(item);
        }
    }

    public enum AllItems  // All available items in the game MUST ADD NEW ITEMS TO THIS LIST FOR THEM TO WORK
    {
        Key1, 
        Key2,
        Key3, 
        Key4,
        Key5, 
        Key6,

        PuzzlePiece1, 
        PuzzlePiece2, 
        PuzzlePiece3, 
        PuzzlePiece4
    }


}
