using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newspaper : CollectibleObject
{
    [SerializeField]
    private string description;

    [SerializeField]
    private int newspaperId;

    private bool inInventory;

    public Newspaper(int newspaperId, string description, bool inInventory)
    {
        this.newspaperId = newspaperId;
        this.description = description;
        this.inInventory = inInventory;
    }
    public string GetDescription()
    {
        return description;
    }
    public bool GetInInventory()
    {
        return inInventory;
    }
    public int GetNewspaperId()
    {
        return newspaperId;
    }
    public void SetInInventory(bool state)
    {
        inInventory = state;
    }

    protected override void AddInventory()
    {
        FindObjectOfType<InventorySystem>().AddNewspaper(this);
    }
}
