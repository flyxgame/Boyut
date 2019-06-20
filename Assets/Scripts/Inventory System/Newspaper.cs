using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newspaper : CollectibleObject
{
    [SerializeField]
    private string description;

    public string GetDescription()
    {
        return description;
    }

    protected override void AddInventory()
    {
        FindObjectOfType<InventorySystem>().AddNewspaper(this);
    }
}
