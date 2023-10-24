using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    Default,
    Keys,
    PuzzleObjects,
    Other


}

public class ItemObject : ScriptableObject
{
    public GameObject prefab;
    public ItemType type;
    [TextArea (15, 20)]
    public string description;




}
